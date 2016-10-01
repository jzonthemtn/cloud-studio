using Amazon.EC2.Model;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.RDS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Model
{
    public class FilteredRdsInstance : FilteredObject
    {

        private FilteredRdsInstance() { }

        [Browsable(true)]
        [ReadOnly(true)]
        public int AllocatedStorage { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public bool AutoMinorVersionUpgrade { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string AvailabilityZone { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public int BackupRetentionPeriod { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string CACertificateIdentifier { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string DBInstanceIdentifier { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string DBInstanceStatus { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string DBName { get; set; }

        // TODO: DBParameterGroups
        // TODO: DBSecurityGroups

        [Browsable(true)]
        [ReadOnly(true)]
        public string Endpoint { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string Engine { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string EngineVersion { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string InstanceCreateTime { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public int Iops { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string LatestRestorableTime { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string LicenseModel { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string MasterUsername { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public bool MultiAZ { get; set; }

        // TODO: OptionGroupMemberships
        // TODO: PendingModifiedValues

        [Browsable(true)]
        [ReadOnly(true)]
        public string PreferredBackupWindow { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string PreferredMaintenanceWindow { get; set; }
                 
        [Browsable(true)]
        [ReadOnly(true)]
        public bool PubliclyAccessible { get; set; }

        // TODO: ReadReplicaDBInstanceIdentifiers 

        [Browsable(true)]
        [ReadOnly(true)]
        public string ReadReplicaSourceDBInstanceIdentifier { get; set; }
         
        [Browsable(true)]
        [ReadOnly(true)]
        public string SecondaryAvailabilityZone { get; set; }

        // TODO: StatusInfos 
        // TODO: VpcSecurityGroups

        public static FilteredRdsInstance FromDbInstance(DBInstance dbInstance)
        {

            FilteredRdsInstance filteredRdsInstance = new FilteredRdsInstance();

            filteredRdsInstance.AllocatedStorage = dbInstance.AllocatedStorage;
            filteredRdsInstance.AutoMinorVersionUpgrade = dbInstance.AutoMinorVersionUpgrade;
            filteredRdsInstance.AvailabilityZone = dbInstance.AvailabilityZone;
            filteredRdsInstance.BackupRetentionPeriod = dbInstance.BackupRetentionPeriod;
            filteredRdsInstance.CACertificateIdentifier = dbInstance.CACertificateIdentifier;
            filteredRdsInstance.DBInstanceIdentifier = dbInstance.DBInstanceIdentifier;
            filteredRdsInstance.DBInstanceStatus = dbInstance.DBInstanceStatus;
            filteredRdsInstance.DBName = dbInstance.DBName;
            filteredRdsInstance.Endpoint = dbInstance.Endpoint.Address + ":" + dbInstance.Endpoint.Port;
            filteredRdsInstance.Engine = dbInstance.Engine;
            filteredRdsInstance.EngineVersion = dbInstance.EngineVersion;
            filteredRdsInstance.InstanceCreateTime = dbInstance.InstanceCreateTime.ToString();
            filteredRdsInstance.Iops = dbInstance.Iops;
            filteredRdsInstance.LatestRestorableTime = dbInstance.LatestRestorableTime.ToString();
            filteredRdsInstance.LicenseModel = dbInstance.LicenseModel;
            filteredRdsInstance.MasterUsername = dbInstance.MasterUsername;
            filteredRdsInstance.MultiAZ = dbInstance.MultiAZ;
            filteredRdsInstance.PreferredBackupWindow = dbInstance.PreferredBackupWindow;
            filteredRdsInstance.PreferredMaintenanceWindow = dbInstance.PreferredMaintenanceWindow;
            filteredRdsInstance.PubliclyAccessible = dbInstance.PubliclyAccessible;
            filteredRdsInstance.ReadReplicaSourceDBInstanceIdentifier = dbInstance.ReadReplicaSourceDBInstanceIdentifier;
            filteredRdsInstance.SecondaryAvailabilityZone = dbInstance.SecondaryAvailabilityZone;

            return filteredRdsInstance;

        }

    }

}
