﻿using System;
using System.Runtime.Serialization;

namespace TCore
{
//    [DataContract]
	public class SRBase	// StatusResponse XML
	{
		bool fResult;
		string sReason;
        Guid crids;

//        [DataMember]
		public bool Result { get { return fResult;} set { fResult = value;}}

//        [DataMember]
		public string Reason { get { return sReason;} set { sReason = value;}}

//        [DataMember]
		public bool Succeeded { get { return fResult;}}

        public Guid CorrelationID { get { return crids; } set { crids = value; } }
	}

//    [DataContract]
    public class SR : SRBase
	{
		static public SR Success()
		{
			SR sr = new SR();
			sr.Result = true;
			sr.Reason = null;

			return sr;
		}

		static public SR SuccessCorrelate(Guid crids)
		{
			SR sr = new SR();
			sr.Result = true;
			sr.Reason = null;
            sr.CorrelationID = crids;

			return sr;
		}
		static public SR Failed(Exception e)
		{
			SR sr = new SR();
			sr.Result = false;
			sr.Reason = e.Message;

			return sr;
		}

		static public SR Failed(string sReason)
		{
			SR sr = new SR();
			sr.Result = false;
			sr.Reason = sReason;

			return sr;
		}

 		static public SR FailedCorrelate(Exception e, Guid crids)
		{
			SR sr = new SR();
			sr.Result = false;
			sr.Reason = e.Message;
            sr.CorrelationID = crids;

			return sr;
		}

		static public SR FailedCorrelate(string sReason, Guid crids)
		{
			SR sr = new SR();
			sr.Result = false;
			sr.Reason = sReason;
            sr.CorrelationID = crids;
			return sr;
		}
    }

    [DataContract]
    public class SRXML : SRBase	// StatusResponse XML
	{
		string sXML;
		DateTime dttm;

//		[DataMember]
		public string XML { get { return sXML;} set { sXML = value;}}

//		[DataMember]
		public DateTime Dttm { get { return dttm;} set { dttm = value;}}

		public SRXML(SR sr)
		{
			sXML = null;
			dttm = DateTime.Now;

			Reason = sr.Reason;
			Result = sr.Result;
            CorrelationID = sr.CorrelationID;
		}

	}
}
