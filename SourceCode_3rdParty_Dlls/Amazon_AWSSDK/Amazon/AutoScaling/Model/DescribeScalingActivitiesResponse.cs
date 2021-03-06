﻿namespace Amazon.AutoScaling.Model
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    [XmlRoot(Namespace="http://autoscaling.amazonaws.com/doc/2009-05-15/", IsNullable=false)]
    public class DescribeScalingActivitiesResponse
    {
        private Amazon.AutoScaling.Model.DescribeScalingActivitiesResult describeScalingActivitiesResultField;
        private Amazon.AutoScaling.Model.ResponseMetadata responseMetadataField;

        public bool IsSetDescribeScalingActivitiesResult()
        {
            return (this.describeScalingActivitiesResultField != null);
        }

        public bool IsSetResponseMetadata()
        {
            return (this.responseMetadataField != null);
        }

        public string ToXML()
        {
            StringBuilder sb = new StringBuilder(0x400);
            XmlSerializer serializer = new XmlSerializer(base.GetType());
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize((TextWriter) writer, this);
            }
            return sb.ToString();
        }

        public DescribeScalingActivitiesResponse WithDescribeScalingActivitiesResult(Amazon.AutoScaling.Model.DescribeScalingActivitiesResult describeScalingActivitiesResult)
        {
            this.describeScalingActivitiesResultField = describeScalingActivitiesResult;
            return this;
        }

        public DescribeScalingActivitiesResponse WithResponseMetadata(Amazon.AutoScaling.Model.ResponseMetadata responseMetadata)
        {
            this.responseMetadataField = responseMetadata;
            return this;
        }

        [XmlElement(ElementName="DescribeScalingActivitiesResult")]
        public Amazon.AutoScaling.Model.DescribeScalingActivitiesResult DescribeScalingActivitiesResult
        {
            get
            {
                return this.describeScalingActivitiesResultField;
            }
            set
            {
                this.describeScalingActivitiesResultField = value;
            }
        }

        [XmlElement(ElementName="ResponseMetadata")]
        public Amazon.AutoScaling.Model.ResponseMetadata ResponseMetadata
        {
            get
            {
                return this.responseMetadataField;
            }
            set
            {
                this.responseMetadataField = value;
            }
        }
    }
}

