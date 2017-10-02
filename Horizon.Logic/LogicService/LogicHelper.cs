using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicService
{
  public class LogicHelper
  {
    private static LogicHelper _instance;

    private LogicHelper()
    {

    }

    public static LogicHelper Instance
    {
      get
      {
        if (_instance == null) _instance = new LogicHelper();
        return _instance;
      }
    }
  }
}