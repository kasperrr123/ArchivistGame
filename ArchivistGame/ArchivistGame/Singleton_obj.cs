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

        public int Points { get; set; }
        public int Antal_Rigtige { get; set; }

        public Emne Emne { get; set; }

        private Singleton_obj()
        {
            Points = 0;
            Antal_Rigtige = 0;

        }

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



        internal void Reset()
        {
            instance = new Singleton_obj();
        }
    }
}

