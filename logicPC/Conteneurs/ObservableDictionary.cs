using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Windows;



namespace logicPC.Conteneurs
{
    public class LogicEventDictionnary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>
    {
        public Dictionary<Tkey, Tvalue> Items = new();
        public LogicEventDictionnary() : base() { }
        public LogicEventDictionnary(int capacity) : base(capacity) { }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnValueChanged(Object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
            if (null != handler) 
                handler(this, e);
        }

        public bool EAddItem(Tkey key, Tvalue value)
        {
            try
            {
                Items.Add(key, value);
                OnValueChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public new bool ContainsKey(Tkey key) => Items.ContainsKey(key);
        public bool EremoveItem(Tkey key)
        {
            try
            {
                Items.Remove(key);
                OnValueChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}