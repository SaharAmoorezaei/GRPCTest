﻿
using System;
using Zaraban.Shared.Helper;

namespace Zaraban.Shared.Models
{
    public interface IResponseMessage
    {
        string Message { get; set; }
        bool Success { get; set; }
        bool IsTerminated { get; set; }
        /// <summary>
        /// Print Message
        /// </summary>
        void Print();
    }


    public class ResponseMessage: IResponseMessage
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool IsTerminated { get; set; }
        /// <summary>
        /// write response in Console
        /// </summary>
        public void Print()
        {
            Console.WriteLine(Message);
        }
    }


    public class ConsoleResponseMessage : IResponseMessage
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool IsTerminated { get; set; }

        /// <summary>
        /// write respnse in console
        /// </summary>
        public void Print()
        {
            if (!Success)
            {
                ConsoleHelper.LogWarning("> " + Message);
                return;
            }
            Console.WriteLine("> " + Message);
        }
    }

    public class WebResponseMessage: IResponseMessage
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool IsTerminated { get; set; }

        public void Print()
        {
            if (!Success)
            {
               Console.WriteLine( $"<div class=\"Error\">{Message}</div>");
            }

            Console.WriteLine($"<div class=\"Success\">{Message}</div>");
        }
    }


    public class EmojioResponseMessage : IResponseMessage
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool IsTerminated { get; set; }

        public void Print()
        {
            switch (Message.ToLower())
            {
                case "hi":
                    Console.WriteLine("✋");
                    break;
                case "bye":
                    Console.WriteLine("👋");
                    break;
                case "pong":
                    Console.WriteLine("🏓");
                    break;
                default:
                    Console.WriteLine("❌");
                    break;
            }
        }
    }
}
