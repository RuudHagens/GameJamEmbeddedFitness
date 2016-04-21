//----------------------------------------------------------------------------
//  Copyright (C) 2004-2016 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.VideoSurveillance;
using Emgu.Util;

namespace MotionDetection
{
   public partial class Form1 : Form
   {
      private Capture _capture;
      private MotionHistory _motionHistory;
      private BackgroundSubtractor _forgroundDetector;

      public Form1()
      {
         InitializeComponent();

         //try to create the capture
         if (_capture == null)
         {
            try
            {
               _capture = new Capture();
            }
            catch (NullReferenceException excpt)
            {   //show errors if there is any
               MessageBox.Show(excpt.Message);
            }
         }

         if (_capture != null) //if camera capture has been successfully created
         {
            _motionHistory = new MotionHistory(
                1.0, //in second, the duration of motion history you wants to keep
                0.05, //in second, maxDelta for cvCalcMotionGradient
                0.5); //in second, minDelta for cvCalcMotionGradient

            _capture.ImageGrabbed += ProcessFrame;
            _capture.Start();
         }
      }

      private Mat _segMask = new Mat();
      private Mat _forgroundMask = new Mat();
      private void ProcessFrame(object sender, EventArgs e)
      {
         Mat image = new Mat();

         _capture.Retrieve(image);
         if (_forgroundDetector == null)
         {
            _forgroundDetector = new BackgroundSubtractorMOG2();
         }
            capturedImage.Image = image;
         _forgroundDetector.Apply(image, _forgroundMask);

         //update the motion history
         _motionHistory.Update(_forgroundMask);
            
                  

         #region get a copy of the motion mask and enhance its color
         double[] minValues, maxValues;
         Point[] minLoc, maxLoc;
         _motionHistory.Mask.MinMax(out minValues, out maxValues, out minLoc, out maxLoc);
         Mat motionMask = new Mat();
         using (ScalarArray sa = new ScalarArray(255.0 / maxValues[0]))
            CvInvoke.Multiply(_motionHistory.Mask, sa, motionMask, 1, DepthType.Cv8U);
         //Image<Gray, Byte> motionMask = _motionHistory.Mask.Mul(255.0 / maxValues[0]);
         #endregion

         //create the motion image 
         Mat motionImage = new Mat(motionMask.Size.Height, motionMask.Size.Width, DepthType.Cv8U, 3);
         //display the motion pixels in blue (first channel)
         //motionImage[0] = motionMask;
         CvInvoke.InsertChannel(motionMask, motionImage, 0);

         //Threshold to define a motion area, reduce the value to detect smaller motion
         double minArea = 1000;

         //storage.Clear(); //clear the storage
         Rectangle[] rects;
         using (VectorOfRect boundingRect = new VectorOfRect())
         {
            _motionHistory.GetMotionComponents(_segMask, boundingRect);
            rects = boundingRect.ToArray();
         }

            long procesingtime;
            Rectangle[] results = FindPedestrian.Find(image, true, out procesingtime);
            foreach (Rectangle rect in results)
            {
                CvInvoke.Rectangle(image, rect, new Bgr(Color.Red).MCvScalar);
            }

         if (this.Disposing || this.IsDisposed)
            return;


            afterProcesImage.Image = image;


      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {

         if (disposing && (components != null))
         {
            components.Dispose();
         }

         base.Dispose(disposing);
      }

      private void Form1_FormClosed(object sender, FormClosedEventArgs e)
      {
         _capture.Stop();
      }
    }
}
