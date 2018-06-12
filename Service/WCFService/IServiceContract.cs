using SqlModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFService
{

    //[ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        DateTime GetDateTime();
        [OperationContract]
        List<appleAcount> GetAllUserInfos();
        [OperationContract]
        appleAcount GetAUserInfo(int id);
        [OperationContract]
        appleAcount Login();
        [OperationContract]
        appleAcount ParallelTest();
        [OperationContract]
        bool DeleteUserInfo(appleAcount userInfo);
        [OperationContract]
        int EditUserInfo(appleAcount userInfo);
        [OperationContract]
        bool AddUserInfo(appleAcount userInfo);
        [OperationContract]
        string GetOrder();

    }

}
