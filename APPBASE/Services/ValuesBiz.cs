using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPBASE.Svcbiz
{
    public class valFLAG : Svcapp.valFLAG
    {
        //Employee BP_STS Active/Inactive
        public const string FLAG_EMPBPSTS_ACTIVE = "LOV_HRS_EMP_EXISTS_ACTIVE";
        public const string FLAG_EMPBPSTS_INACTIVE = "LOV_HRS_EMP_EXISTS_QUIT";

        //USER_STS
        public const int FLAG_USER_STS_ACTIVE_ID = 1;
        public const string FLAG_USER_STS_ACTIVE = "Aktif";
        public const int FLAG_USER_STS_INACTIVE_ID = 0;
        public const string FLAG_USER_STS_INACTIVE = "Tidak Aktif";

        //ROLE_ID
        public const int FLAG_ROLE_SM = 1;
        public const int FLAG_ROLE_SA = 2;
        public const int FLAG_ROLE_PC = 3;
        public const int FLAG_ROLE_SC = 4;
        public const int FLAG_ROLE_CT = 5;
        public const int FLAG_ROLE_ADM = 6;
        public const int FLAG_ROLE_P = 7;

        //1=CALLENDAR;2=ACTIVITY;3=ANNOUNCEMENT;4=WARNING;5=SUGGESTION
        //TIMELINE_TYPE
        public const Byte FLAG_TIMELINE_TYPE_CALLENDAR = 1;
        public const Byte FLAG_TIMELINE_TYPE_ACTIVITY = 2;
        public const Byte FLAG_TIMELINE_TYPE_ANNOUNCEMENT = 3;
        public const Byte FLAG_TIMELINE_TYPE_WARNING = 4;
        public const Byte FLAG_TIMELINE_TYPE_SUGGESTION = 5;

        //SHARED_GROUP : 1=PUBLIC;2=EMPLOYEES;3=PARENTS;
        public const int FLAG_SHARED_GROUP_PUBLIC = 1;
        public const int FLAG_SHARED_GROUP_EMPLOYEES = 2;
        public const int FLAG_SHARED_GROUP_PARENTS = 3;

        //CLASSTYPE_ID : 1=PUBLIC;2=EMPLOYEES;3=PARENTS;
        public const int FLAG_CLASSTYPE_ID_TODDLER = 1;
        public const int FLAG_CLASSTYPE_ID_PLAYGROUP = 2;
        public const int FLAG_CLASSTYPE_ID_KINDERGARTEN1 = 3;
        public const int FLAG_CLASSTYPE_ID_KINDERGARTEN2 = 4;

        //TRINTYPE : 1 s/d 15
        public const int FLAG_TRINTYPE_SPP = 1;
        public const int FLAG_TRINTYPE_SPPDENDA = 2;
        public const int FLAG_TRINTYPE_MIDGANJIL = 3;
        public const int FLAG_TRINTYPE_MIDGENAP = 4;
        public const int FLAG_TRINTYPE_SEMGANJIL = 5;
        public const int FLAG_TRINTYPE_SEMGENAP = 6;
        public const int FLAG_TRINTYPE_DU = 7;
        public const int FLAG_TRINTYPE_UAT = 8;
        public const int FLAG_TRINTYPE_EKSKUL = 9;
        public const int FLAG_TRINTYPE_SCLUB = 10;
        public const int FLAG_TRINTYPE_PRAKERIN = 11;
        public const int FLAG_TRINTYPE_FORMULIR = 12;
        public const int FLAG_TRINTYPE_UPANGKAL = 13;
        public const int FLAG_TRINTYPE_UBUKU = 14;
        public const int FLAG_TRINTYPE_USERAGAM = 15;
        

    } //End public class valFLAG
} //End namespace APPBASE.Svcbiz