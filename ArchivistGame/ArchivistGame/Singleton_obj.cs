using ArchivistGame.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchivistGame
{
    class Singleton_obj
    {
        private static Singleton_obj instance;

        public string Playername { get; set; }

        public Bike Topic { get; set; }

        private Singleton_obj() { }

        public static Singleton_obj Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton_obj();
                }
                return instance;
            }
        }
    }
}

