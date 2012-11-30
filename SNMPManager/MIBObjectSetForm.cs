﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SnmpSharpNet;

namespace SNMPManager
{
    public partial class MIBObjectSetForm : Form
    {
        internal string Value
        {
            get
            {
                return string.IsNullOrEmpty(txtValue.Text) ? null : txtValue.Text.Trim();
            }
        }

        internal DataType Type
        {
            get
            {
                DataType ret = DataType.String;
                if (rdrInteger.Checked)
                    ret = DataType.Integer;
                if (rdrIP.Checked)
                    ret = DataType.IP;
                if (rdrString.Checked)
                    ret = DataType.String;
                if (rdrTimestamp.Checked)
                    ret = DataType.Timestamp;

                return ret;
            }
        }

        public AsnType ConvertedValue()
        {
            switch (Type)
            {
                case DataType.String:
                    return new OctetString(Value);
                case DataType.IP:
                    break;
                case DataType.Integer:
                    break;
                case DataType.Timestamp:
                    break;
                default:
                    break;
            }

            return null;
        }

        public MIBObjectSetForm()
        {
            InitializeComponent();
        }

        public enum DataType
        {
            String,
            IP,
            Integer,
            Timestamp
        }
    }
}
