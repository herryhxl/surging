using FileLoder.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileLoder.TemplateModel;
using FileLoder.T_AdoNet;
using FileLoder.T_Android;
using FileLoder.T_DotnetCore;

namespace FileLoder.Helper
{

    public class NewFileFactory
    {
        private readonly string _outputPath;
        private readonly string _projectName;
        private readonly string _templatePath;
        private readonly string _apiName;
        private readonly string _mapText;
        private readonly string _repositoryText;
        private readonly Main.UpdateUi _update;
        private readonly Main _myUi;
        private readonly SaveOptions _options;
        private readonly string _package;
        private readonly string _layoutPath;
        private readonly bool _pro;

        public NewFileFactory(CodePara code, Main.UpdateUi update, Main myUi)
        {
            _projectName = code.Option.NameSpace;
            _templatePath = Path.GetFullPath("./Templates/");
            _outputPath = code.Option.OutPath + "//";
            _apiName = code.Option.ApiNameSpace;
            _mapText = code.Option.MapText;
            _repositoryText = code.Option.RepositoryText;
            _update = update;
            _myUi = myUi;
            _options = code.Option;
            _pro = code.Option.Procedures && code.Option.DataBaseType == DataBaseType.MSSQL;
            _package = code.Option.OutPath.IndexOf("com", StringComparison.Ordinal) == -1
                ? ""
                : code.Option.OutPath.Substring(code.Option.OutPath.IndexOf("com", StringComparison.Ordinal)).Replace("\\", ".");

            _layoutPath = _outputPath.IndexOf("java", StringComparison.Ordinal) == -1
               ? ""
               : _outputPath.Substring(0, _outputPath.IndexOf("java", StringComparison.Ordinal)) + "res\\";
        }

        public void WriteFile(CodePara model)
        {
            if (_options.CreateCodeType == CreateCodeType.AdoNet代码)
            {
                WriteAdoNetFile(model.TableList);
            }
            else if (_options.CreateCodeType == CreateCodeType.CodeFirst代码)
            {
                WriteCodeFirstFile(model);
            }
            else if (_options.CreateCodeType == CreateCodeType.EFCore代码)
            {
                WriteDotNetCoreFile(model);
            }
            else if (_options.CreateCodeType == CreateCodeType.Android代码)
            {
                WriteAndroidFile(model.TableList);
            }
            else if (_options.CreateCodeType == CreateCodeType.LigerUI代码)
            {
                WriteLigerUIFile(model.TableList);
            }
        }

        private void WriteLigerUIFile(List<TableModel> model)
        {
            ReportInfo info = new ReportInfo
            {
                Percent = 0,
                Message = "开始生成【" + _projectName + "】项目代码,共有【" + model.Count + "】张数据表"
            };
            _myUi.Invoke(_update, info, null);
            var Sum = 0;
            if (_options.Controller)
                Sum += 1;
            if (_options.ViewModels)
                Sum += 1;
            double p = 100 / Sum / model.Count;
            model.ForEach(item =>
            {
                if (_options.Controller)
                {
                    try
                    {
                        info.Message = "开始生成" + item.Code + "的视图控制器文件";
                        _myUi.Invoke(_update, info, null);
                        RenderControllerUIFile(item);
                        info.Message = "生成" + item.Code + "的视图控制器文件成功";
                        info.Percent += p;
                        _myUi.Invoke(_update, info, null);
                    }
                    catch (Exception e)
                    {
                        //RenderModelFile(item);
                        info.Message = "生成" + item.Code + "的视图控制器文件失败【" + e.Message + "】";
                        info.Percent += p;
                        _myUi.Invoke(_update, info, e.Message);
                    }
                }
                if (_options.ViewModels)
                {
                    try
                    {
                        info.Message = "开始生成" + item.Code + "的视图文件";
                        _myUi.Invoke(_update, info, null);
                        RenderControllerViewFile(item, model);
                        info.Message = "生成" + item.Code + "的视图文件成功";
                        info.Percent += p;
                        _myUi.Invoke(_update, info, null);
                    }
                    catch (Exception e)
                    {
                        //RenderModelFile(item);
                        info.Message = "生成" + item.Code + "的视图文件失败【" + e.Message + "】";
                        info.Percent += p;
                        _myUi.Invoke(_update, info, e.Message);
                    }
                }
            });
        }

        private void WriteAndroidFile(List<TableModel> model)
        {
            ReportInfo info = new ReportInfo
            {
                Percent = 0,
                Message = "开始生成【" + _projectName + "】项目代码,共有【" + model.Count + "】张数据表"
            };
            _myUi.Invoke(_update, info, null);
            double one = 0;
            if (_options.Base)
            {
                #region 生成Base文件
                try
                {
                    info.Message = "开始生成基础Base配置文件";
                    _myUi.Invoke(_update, info, null);
                    _options.Base = false;
                    RenderJBaseFile(model);
                    RenderJCommonFile();
                    RenderJDialogFile();
                    RenderJLayoutMainFile(model);
                    RenderJEventMainFile(model);
                    RenderJDataViewMainFile(model);
                    RenderJDataViewMainEventFile(model);
                    info.Message = "开始生成基础Base配置文件成功";
                    info.Percent += 5;
                    one = 5;
                    _myUi.Invoke(_update, info, null);
                }
                catch (Exception e)
                {
                    info.Message = "生成基础Base配置文件失败【" + e.Message + "】";
                    info.Percent += 5;
                    one = 5;
                    _myUi.Invoke(_update, info, e.Message);
                }
                #endregion
            }
            int Sum = 0;
            if (_options.Entity) Sum += 1;
            if (_options.Service) Sum += 3;
            if (_options.ViewModels) Sum += 6;
            if (Sum > 0)
            {
                double p = (100.00 - one) / Sum / model.Count;
                model.ForEach(item =>
                {
                    if (_options.Entity)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的模型文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJModelFile(item, model);
                            info.Message = "生成" + item.Code + "的模型文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的模型文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                        //try
                        //{
                        //    info.Message = "开始生成" + item.Code + "的模型List文件";
                        //    _myUi.Invoke(_update, info, null);
                        //    RenderJModelListFile(item);
                        //    info.Message = "生成" + item.Code + "的模型List文件成功";
                        //    info.Percent += p;
                        //    _myUi.Invoke(_update, info, null);
                        //}
                        //catch (Exception e)
                        //{
                        //    //RenderModelFile(item);
                        //    info.Message = "生成" + item.Code + "的模型List文件失败【" + e.Message + "】";
                        //    info.Percent += p;
                        //    _myUi.Invoke(_update, info, e.Message);
                        //}
                    }
                    if (_options.Service)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的接口文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJIServiceFile(item);
                            info.Message = "生成" + item.Code + "的接口文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的接口文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的接口实现文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJServiceFile(item);
                            info.Message = "生成" + item.Code + "的接口实现文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的接口实现文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的业务逻辑实现文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJDataFile(item);
                            info.Message = "生成" + item.Code + "的业务逻辑实现文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的业务逻辑实现文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                    }
                    if (_options.ViewModels)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的绑定模型文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJViewModelFile(item, model);
                            info.Message = "生成" + item.Code + "的绑定模型文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的绑定模型文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的布局文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJLayoutFile(item);
                            info.Message = "生成" + item.Code + "的布局文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的事件文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的Item布局文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJLayoutItemFile(item);
                            info.Message = "生成" + item.Code + "的布局Item文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的布局Item文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的事件文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJEventFile(item, model);
                            info.Message = "生成" + item.Code + "的事件文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的事件文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }

                        try
                        {
                            info.Message = "开始生成" + item.Code + "的Adapter文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJAdapterFile(item);
                            info.Message = "生成" + item.Code + "的Adapter文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的Adapter文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }

                        try
                        {
                            info.Message = "开始生成" + item.Code + "的Fragment文件";
                            _myUi.Invoke(_update, info, null);
                            RenderJFragmentFile(item);
                            info.Message = "生成" + item.Code + "的Fragment文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的Fragment文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                    }
                });
            }
            info.Message = "生成【" + _projectName + "】项目代码成功";
            info.Percent = 100;
            _myUi.Invoke(_update, info, null);
        }

        private void WriteAdoNetFile(List<TableModel> model)
        {
            ReportInfo info = new ReportInfo { Percent = 0 };
            info.Message = "开始生成【" + _projectName + "】项目代码,共有【" + model.Count + "】张数据表";
            _myUi.Invoke(_update, info, null);
            int Sum = 0;
            if (_options.Base) Sum += 1;
            if (_options.Entity) Sum += 1;
            if (_options.Service) Sum += 1;
            if (_options.ViewModels) Sum += 1;
            if (Sum > 0)
            {
                double p = 100.00 / Sum / model.Count;
                model.ForEach(item =>
                {
                    if (_options.Base)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的接口文件";
                            _myUi.Invoke(_update, info, null);
                            RenderNewIServiceFile(item);
                            info.Message = "生成" + item.Code + "的接口文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的接口文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                    }
                    if (_options.Entity)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的模型文件";
                            _myUi.Invoke(_update, info, null);
                            RenderNewModelFile(item);
                            info.Message = "生成" + item.Code + "的模型文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的模型文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                    }
                    if (_options.Service)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的接口实现文件";
                            _myUi.Invoke(_update, info, null);
                            RenderNewServiceFile(item);
                            info.Message = "生成" + item.Code + "的接口实现文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的接口实现文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                    }
                    if (_options.ViewModels)
                    {
                        try
                        {
                            info.Message = "开始生成" + item.Code + "的业务逻辑实现文件";
                            _myUi.Invoke(_update, info, null);
                            RenderNewBllFile(item);
                            info.Message = "生成" + item.Code + "的业务逻辑实现文件成功";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, null);
                        }
                        catch (Exception e)
                        {
                            //RenderModelFile(item);
                            info.Message = "生成" + item.Code + "的业务逻辑实现文件失败【" + e.Message + "】";
                            info.Percent += p;
                            _myUi.Invoke(_update, info, e.Message);
                        }
                    }
                });
            }
            info.Message = "生成【" + _projectName + "】项目代码成功";
            info.Percent = 100;
            _myUi.Invoke(_update, info, null);
        }

        private void WriteCodeFirstFile(CodePara model)
        {
            var SkipEnum = new List<string>();

            SkipEnum.Add("Area_Type");
            SkipEnum.Add("UserRole_RoleType");
            SkipEnum.Add("Platform_Status");
            SkipEnum.Add("Platform_Type");
            SkipEnum.Add("OrgApply_Status");
            SkipEnum.Add("Org_OrgType");
            SkipEnum.Add("SuperUserInfo_Sex");
            SkipEnum.Add("OrgApply_OrgType");
            SkipEnum.Add("UserRole_Type");
            SkipEnum.Add("MenuAction_Status");
            SkipEnum.Add("FieldInfo_SearchType");
            SkipEnum.Add("FieldInfo_InType");
            SkipEnum.Add("FieldInfo_KeyType");
            SkipEnum.Add("MenuAction_Type");
            SkipEnum.Add("MenuAction_MenuType");
            SkipEnum.Add("MenuAction_ActionType");
            SkipEnum.Add("SuperUser_PassWordLevel");
            SkipEnum.Add("MenuAuth_InType");
            SkipEnum.Add("MenuAction_MenuLocation");
            SkipEnum.Add("MenuAuth_DataType");
            SkipEnum.Add("MenuAuth_ShowType");
            SkipEnum.Add("MenuAuth_Type");
            SkipEnum.Add("MenuAuth_AuthType");
            SkipEnum.Add("PairOrg_Status");


            var ReplaceName = new Dictionary<string, string>();
            ReplaceName.Add("SuperUser_PassWordLevel", "PassWordLevel");
            ReplaceName.Add("MenuAuth_InType", "FieldInfo_InType");
            ReplaceName.Add("LoginInfo_AppId", "ClientType");
            ReplaceName.Add("MenuActionLog_AppId", "ClientType");
            ReplaceName.Add("SuperUser_RegFrom", "ClientType");


            ReportInfo minfo = new ReportInfo { Percent = 0 };
            minfo.Message = "开始生成【" + _projectName + "】项目代码,共有【" + model.TableList.Count + "】张数据表";
            _myUi.Invoke(_update, minfo, null);

            int p = 1;
            //if (_options.Base) p++;
            if (_options.Entity) p++;
            if (_options.Mappings) p++;
            if (_options.Service) p++;
            if (_options.BaseService) p++;
            if (_pro) p++;
            if (_options.Controller) p++;
            if (_options.ViewModels) p++;
            if (_options.ChangeService) p++;

            double rp = 90.00 / p / model.TableList.Count;

            List<EnumModel> em = new List<EnumModel>();
            try
            {
                minfo.Message = "开始生成基础Configuration配置文件的模型文件";
                _myUi.Invoke(_update, minfo, null);
                RenderConfigurationFile(model.TableList);
                minfo.Message = "开始生成基础Configuration配置文件成功";
                minfo.Percent += 5;
                _myUi.Invoke(_update, minfo, null);
            }
            catch (Exception e)
            {
                minfo.Message = "生成基础Configuration配置文件【" + e.Message + "】";
                minfo.Percent += p;
                _myUi.Invoke(_update, minfo, e.Message);
            }
            try
            {
                if (_options.Base)
                {
                    minfo.Message = "开始生成基础Base配置文件";
                    _myUi.Invoke(_update, minfo, null);
                    RenderBaseDataFile();
                    minfo.Message = "开始生成基础Base配置文件成功";
                    minfo.Percent += 5;
                    _myUi.Invoke(_update, minfo, null);
                }
            }
            catch (Exception e)
            {
                minfo.Message = "生成基础Base配置文件失败【" + e.Message + "】";
                minfo.Percent += 5;
                _myUi.Invoke(_update, minfo, e.Message);
            }

            foreach (var tableitem in model.TableList)
            {
                if (_options.Base)
                {
                    if (tableitem.ColumnsList.Any(t => t.EM))
                    {
                        tableitem.ColumnsList.Where(t => t.EM).ToList().ForEach(FieldName =>
                        {
                            var EmunName = tableitem.Code + "_" + FieldName.Code;
                            if (_options.MapText == "IMySqlMapping" || _options.MapText == "IMapping")
                            {
                                if (!SkipEnum.Contains(EmunName))
                                {
                                    em.Add(new EnumModel
                                    {
                                        EnumName = EmunName,
                                        Values = FieldName.EmodelList
                                    });
                                }
                            }
                            else
                            {
                                em.Add(new EnumModel
                                {
                                    EnumName = EmunName,
                                    Values = FieldName.EmodelList
                                });
                            }
                        });
                    }
                }
                int rr = 1;
                tableitem.ColumnsList.Where(t => t.OrderBy).ToList().ForEach(field =>
                {
                    if (field.EM)
                    {
                        var EnumName = tableitem.Code + "_" + field.Code;
                        if (_options.MapText == "IMySqlMapping" || _options.MapText == "IMapping")
                        {
                            if (ReplaceName.ContainsKey(EnumName))
                            {
                                field.EnumName = ReplaceName[EnumName];
                            }
                            else if (SkipEnum.Contains(EnumName))
                            {
                                field.EnumName = EnumName;
                            }
                            else
                            {
                                field.EnumName = _projectName + "_E." + EnumName;
                            }
                        }
                        else
                        {
                            field.EnumName = _projectName + "_E." + EnumName;
                        }
                    }
                    field.Id = rr + "";
                    rr++;
                });
                if (_options.Entity)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "Entity模型文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderEntityFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "Entity模型文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "Entity模型文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }

                }
                if (_options.Mappings)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "模型映射文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderMappingFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "模型映射文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);

                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "模型映射文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_options.ChangeService)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "方法实现ChangeService文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderChangeServiceFile(tableitem, model.AllTableList);
                        minfo.Message = "生成" + tableitem.Code + "方法实现ChangeService文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }

                if (_options.Service)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "方法实现Service文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderServiceFile(tableitem, model.AllTableList);
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_options.BaseService)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "搜索模型文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderSearchFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "搜索模型文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "搜索模型文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "方法实现BaseService文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderBaseServiceFile(tableitem, model.AllTableList);
                        minfo.Message = "生成" + tableitem.Code + "方法实现BaseService文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_pro)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "存储过程和方法执行文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderSqlFunctionFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "存储过程和方法执行文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "存储过程和方法执行文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }

                if (_options.Controller)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "WebAPI控制器文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderControllerFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "WebAPI控制器文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "WebAPI控制器文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_options.ViewModels)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "视图模型文件";
                        _myUi.Invoke(_update, minfo, null);
                        RenderViewModel(tableitem);
                        minfo.Message = "生成" + tableitem + "视图模型文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem + "视图模型文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
            }
            if (_options.Base && em.Any())
                RenderEnumFile(em);
            minfo.Message = "生成【" + _projectName + "】项目代码成功";
            minfo.Percent = 100;
            _myUi.Invoke(_update, minfo, null);
        }

        private void WriteDotNetCoreFile(CodePara model)
        {
            var SkipEnum = new List<string>();
            ReportInfo minfo = new ReportInfo { Percent = 0 };
            minfo.Message = "开始生成【" + _projectName + "】项目代码,共有【" + model.TableList.Count + "】张数据表";
            _myUi.Invoke(_update, minfo, null);

            int p = 1;
            //if (_options.Base) p++;
            if (_options.Entity) p++;
            if (_options.Mappings) p++;
            if (_options.Service) p++;
            if (_options.BaseService) p++;
            if (_pro) p++;
            if (_options.Controller) p++;
            if (_options.ViewModels) p++;
            if (_options.ChangeService) p++;

            double rp = 90.00 / p / model.TableList.Count;

            List<EnumModel> em = new List<EnumModel>();
            //try
            //{
            //    minfo.Message = "开始生成基础Configuration配置文件的模型文件";
            //    _myUi.Invoke(_update, minfo, null);
            //    RenderConfigurationFile(model.TableList);
            //    minfo.Message = "开始生成基础Configuration配置文件成功";
            //    minfo.Percent += 5;
            //    _myUi.Invoke(_update, minfo, null);
            //}
            //catch (Exception e)
            //{
            //    minfo.Message = "生成基础Configuration配置文件【" + e.Message + "】";
            //    minfo.Percent += p;
            //    _myUi.Invoke(_update, minfo, e.Message);
            //}
            try
            {
                if (_options.Base)
                {
                    minfo.Message = "开始生成基础Base配置文件";
                    _myUi.Invoke(_update, minfo, null);
                    CoreRenderBaseDataFile(model.TableList);
                    minfo.Message = "开始生成基础Base配置文件成功";
                    minfo.Percent += 5;
                    _myUi.Invoke(_update, minfo, null);
                }
            }
            catch (Exception e)
            {
                minfo.Message = "生成基础Base配置文件失败【" + e.Message + "】";
                minfo.Percent += 5;
                _myUi.Invoke(_update, minfo, e.Message);
            }

            foreach (var tableitem in model.TableList)
            {
                if (_options.Base)
                {
                    if (tableitem.ColumnsList.Any(t => t.EM))
                    {
                        tableitem.ColumnsList.Where(t => t.EM).ToList().ForEach(FieldName =>
                        {
                            var EmunName = tableitem.Code + "_" + FieldName.Code;
                            if (_options.MapText == "ISuperUserMapping")
                            {
                                if (!SkipEnum.Contains(EmunName))
                                {
                                    em.Add(new EnumModel
                                    {
                                        EnumName = EmunName,
                                        Values = FieldName.EmodelList
                                    });
                                }
                            }
                            else
                            {
                                em.Add(new EnumModel
                                {
                                    EnumName = EmunName,
                                    Values = FieldName.EmodelList
                                });
                            }
                        });
                    }
                }
                int rr = 1;
                tableitem.ColumnsList.Where(t => t.OrderBy).ToList().ForEach(field =>
                {
                    if (field.EM)
                    {
                        var EnumName = tableitem.Code + "_" + field.Code;
                        if (_options.MapText == "IMySqlMapping" || _options.MapText == "IMapping")
                        {
                            if (SkipEnum.Contains(EnumName))
                            {
                                field.EnumName = EnumName;
                            }
                            else
                            {
                                field.EnumName = _projectName + "_E." + EnumName;
                            }
                        }
                        else
                        {
                            field.EnumName = _projectName + "_E." + EnumName;
                        }
                    }
                    field.Id = rr + "";
                    rr++;
                });
                if (_options.Entity)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "Entity模型文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderEntityFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "Entity模型文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "Entity模型文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }

                }
                if (_options.Mappings)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "模型映射文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderMappingFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "模型映射文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);

                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "模型映射文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_options.ChangeService)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "方法实现ChangeService文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderChangeServiceFile(tableitem, model.AllTableList);
                        minfo.Message = "生成" + tableitem.Code + "方法实现ChangeService文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }

                if (_options.Service)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "方法实现Service文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderRepositoryFile(tableitem, model.AllTableList);
                        CoreRenderServiceFile(tableitem, model.AllTableList);
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_options.BaseService)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "搜索模型文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderSearchFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "搜索模型文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "搜索模型文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "方法实现BaseService文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderBaseServiceFile(tableitem, model.AllTableList);
                        minfo.Message = "生成" + tableitem.Code + "方法实现BaseService文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "方法实现Service文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_pro)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "存储过程和方法执行文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderSqlFunctionFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "存储过程和方法执行文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "存储过程和方法执行文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }

                if (_options.Controller)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "WebAPI控制器文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderControllerFile(tableitem);
                        minfo.Message = "生成" + tableitem.Code + "WebAPI控制器文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem.Code + "WebAPI控制器文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
                if (_options.ViewModels)
                {
                    try
                    {
                        minfo.Message = "开始生成" + tableitem.Code + "视图模型文件";
                        _myUi.Invoke(_update, minfo, null);
                        CoreRenderViewModel(tableitem);
                        //生成自定义DtoModel供转换
                        CoreRenderDtoModel(tableitem);
                        minfo.Message = "生成" + tableitem + "视图模型文件成功";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, null);
                    }
                    catch (Exception e)
                    {
                        minfo.Message = "生成" + tableitem + "视图模型文件失败【" + e.Message + "】";
                        minfo.Percent += rp;
                        _myUi.Invoke(_update, minfo, e.Message);
                    }
                }
            }
            if (_options.Base && em.Any())
                RenderEnumFile(em);
            minfo.Message = "生成【" + _projectName + "】项目代码成功";
            minfo.Percent = 100;
            _myUi.Invoke(_update, minfo, null);
        }
        #region 生成NetCore代码
        private void CoreRenderEntityFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Entity\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Entity\\" + mo.Code + "\\");
            }
            var entityOutputPath = _outputPath + "Entity\\" + mo.Code + "\\" + mo.Code +
                                   "Entity.cs";
            var modelTemplate = new CoreModelTemplate(mo, mo.Code, _projectName);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }
        public void CoreRenderSqlFunctionFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Base\\SqlFunction\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\SqlFunction\\");
            }
            var sqlFunctionOutputPath = _outputPath + "Base\\SqlFunction\\" + mo.Code +
                                   ".cs";
            var sqlFunctionTemplate = new CoreSqlFunctionTemplate(mo, mo.Code, _projectName);
            var output = sqlFunctionTemplate.TransformText();
            File.WriteAllText(sqlFunctionOutputPath, output);
        }
        public void CoreRenderMappingFile(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Mappings\\" + models.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Mappings\\" + models.Code + "\\");
            }
            var outputPath = _outputPath + "Mappings\\" + models.Code + "\\" + models.Code + "Mapping.cs";
            var mappingTemplate = new CoreMappingTemplate(models, _projectName, models.Code, _mapText, _options);
            var output = mappingTemplate.TransformText();
            File.WriteAllText(outputPath, output);
        }

        public void CoreRenderEnumFile(List<EnumModel> models)
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var enumTemplate = new CoreEnumTemplate(models, _projectName);
            var output = enumTemplate.TransformText();
            var outputPath = _outputPath + "Base\\" + _projectName + "_E.cs";
            File.WriteAllText(outputPath, output);
        }
        public void CoreRenderConfigurationFile(List<TableModel> models)
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var configurationTemplate = new CoreConfigurationTemplate(models, _projectName, _options);
            var configurationoutput = configurationTemplate.TransformText();
            var configurationoutputPath = _outputPath + "Base\\" + _projectName + "Configuration.cs";
            File.WriteAllText(configurationoutputPath, configurationoutput);
        }




        public void CoreRenderBaseDataFile(List<TableModel> Model)
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var mappingTemplate = new CoreIMappingTemplate(_projectName);
            var mappingoutput = mappingTemplate.TransformText();
            var mappingoutputPath = _outputPath + "Base\\I" + _projectName + "Mapping.cs";
            File.WriteAllText(mappingoutputPath, mappingoutput);

            //var repositoryTemplate = new CoreIRepositoryTemplate(_projectName, _options);
            //var repositoryoutput = repositoryTemplate.TransformText();
            //var repositoryoutputPath = _outputPath + "Base\\I" + _projectName + "Repository.cs";
            //File.WriteAllText(repositoryoutputPath, repositoryoutput);

            var baseExtensionsTemplate = new CoreBaseExtensionsTemplate(_projectName, _options, Model);
            var baseExtensionsoutput = baseExtensionsTemplate.TransformText();
            var baseExtensionsoutputPath = _outputPath + "Base\\" + _projectName + "Extensions.cs";
            File.WriteAllText(baseExtensionsoutputPath, baseExtensionsoutput);

            var baseAutoMapperTemplate = new CoreBaseAutoMapperTemplate(_projectName, _options, Model);
            var baseAutoMapperoutput = baseAutoMapperTemplate.TransformText();
            var baseAutoMapperoutputPath = _outputPath + "Base\\" + _projectName + "Mapper.cs";
            File.WriteAllText(baseAutoMapperoutputPath, baseAutoMapperoutput);

            //var RepositoryTemplate = new CoreRepositoryTemplate(_projectName, _options);
            //var Repositoryoutput = RepositoryTemplate.TransformText();
            //var RepositoryoutputPath = _outputPath + "Base\\" + _projectName + "Repository.cs";
            //File.WriteAllText(RepositoryoutputPath, Repositoryoutput);

            var DbContextTemplate = new CoreDbContextTemplate(_projectName, _options);
            var DbContextoutput = DbContextTemplate.TransformText();
            var DbContextoutputPath = _outputPath + "Base\\" + _projectName + "DbContext.cs";
            File.WriteAllText(DbContextoutputPath, DbContextoutput);

            var DataBaseScriptTemplate = new CoreDataBaseScriptTemplate(_projectName, _options, Model);
            var DataBaseScriptoutput = DataBaseScriptTemplate.TransformText();
            var DataBaseScriptoutputPath = _outputPath + "" + _projectName + _options.DataBaseType.ToString() + ".sql";
            File.WriteAllText(DataBaseScriptoutputPath, DataBaseScriptoutput);
        }
        public void CoreRenderSearchFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Entity\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Entity\\" + mo.Code + "\\");
            }
            var searchTemplate = new CoreConditionTemplate(mo.ColumnsList, mo.Code, _projectName);
            var output = searchTemplate.TransformText();
            var outputPath = _outputPath + "Entity\\" + mo.Code + "\\" + mo.Code +
                             "SearchConditon.cs";
            File.WriteAllText(outputPath, output);
        }

        public void CoreRenderRepositoryFile(TableModel mo, List<TableModel> AllModes)
        {
            if (!Directory.Exists(_outputPath + "Repository\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Repository\\" + mo.Code + "\\");
            }
            var serviceTemplate = new CoreServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            var output = serviceTemplate.TransformText();
            var outputPath = _outputPath + "Repository\\" + mo.Code + "\\" + mo.Code + "Repository.cs";
            File.WriteAllText(outputPath, output);

            var interfaceTemplate = new CoreIServiceTemplate(_projectName, mo.Code, mo, _pro);
            var iOutPut = interfaceTemplate.TransformText();
            var iOutPutPath = _outputPath + "Repository\\" + mo.Code + "\\I" + mo.Code +
                              "Repository.cs";
            File.WriteAllText(iOutPutPath, iOutPut);
        }
        public void CoreRenderServiceFile(TableModel mo, List<TableModel> AllModes)
        {
            if (!Directory.Exists(_outputPath + "Service\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Service\\" + mo.Code + "\\");
            }
            var serviceTemplate = new CoreApplicationServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            var output = serviceTemplate.TransformText();
            var outputPath = _outputPath + "Service\\" + mo.Code + "\\" + mo.Code + "Service.cs";
            File.WriteAllText(outputPath, output);

            var interfaceTemplate = new CoreIApplicationServiceTemplate(_projectName, mo.Code, mo, _pro);
            var iOutPut = interfaceTemplate.TransformText();
            var iOutPutPath = _outputPath + "Service\\" + mo.Code + "\\I" + mo.Code +
                              "Service.cs";
            File.WriteAllText(iOutPutPath, iOutPut);
        }

        public void CoreRenderBaseServiceFile(TableModel mo, List<TableModel> AllModes)
        {
            //if (!Directory.Exists(_outputPath + "BaseService\\"))
            //{
            //    Directory.CreateDirectory(_outputPath + "BaseService\\");
            //}
            //var baseServiceTemplate = new BaseServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            //var output = baseServiceTemplate.TransformText();
            //var outputPath = _outputPath + "BaseService\\" + mo.Code + "BaseService.cs";
            //File.WriteAllText(outputPath, output);

            //var interfaceTemplate = new IBaseServiceTemplate(_projectName, mo.Code, mo, _pro);
            //var iOutPut = interfaceTemplate.TransformText();
            //var iOutPutPath = _outputPath + "BaseService\\I" + mo.Code +
            //                  "BaseService.cs";
            //File.WriteAllText(iOutPutPath, iOutPut);
        }
        public void CoreRenderChangeServiceFile(TableModel mo, List<TableModel> AllModes)
        {
            if (!Directory.Exists(_outputPath + "ChangeService\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "ChangeService\\" + mo.Code + "\\");
            }
            var changeServiceTemplate = new CoreChangeServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            var output = changeServiceTemplate.TransformText();
            var outputPath = _outputPath + "ChangeService\\" + mo.Code + "\\" + mo.Code + "ChangeService.cs";
            var Oldpath = _outputPath + "ChangeService\\" + mo.Code + "\\" + mo.Code +
                               "ChangeService_Old.cs";

            if (File.Exists(outputPath))
            {
                if (!File.Exists(Oldpath))
                    File.Move(outputPath, Oldpath);
            }
            File.WriteAllText(outputPath, output);

            var interfaceChange = new CoreIChangeServiceTemplate(_projectName, mo.Code, mo, _pro);
            var iOutPut = interfaceChange.TransformText();
            var iOutPutPath = _outputPath + "ChangeService\\" + mo.Code + "\\I" + mo.Code +
                              "ChangeService.cs";


            File.WriteAllText(iOutPutPath, iOutPut);
        }

        public void CoreRenderControllerFile(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Controllers\\" + _projectName + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Controllers\\" + _projectName + "\\");
            }
            var controllerTemplate = new CoreControllerTemplate(models, models.Code, _projectName, _apiName, _repositoryText, _pro);
            var output = controllerTemplate.TransformText();
            var outputpath = _outputPath + "Controllers\\" + _projectName + "\\" + models.Code + "Controller.cs";
            File.WriteAllText(outputpath, output);
        }


        public void CoreRenderViewModel(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Models\\"))
            {
                Directory.CreateDirectory(_outputPath + "Models\\");
            }
            var controllerTemplate = new CoreViewModelTemplate(models, models.Code, _projectName);
            var output = controllerTemplate.TransformText();
            var outputpath = _outputPath + "Models\\" + models.Code + "Model.cs";
            File.WriteAllText(outputpath, output);
        }

        public void CoreRenderDtoModel(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "ModelsCustom\\"))
            {
                Directory.CreateDirectory(_outputPath + "ModelsCustom\\");
            }
            var dtoModelTemplate = new CoreDtoModelTemplate(models, models.Code, _projectName);
            var output = dtoModelTemplate.TransformText();
            var outputpath = _outputPath + "ModelsCustom\\" + models.Code + "Dto.cs";
            if (!File.Exists(outputpath))
            {
                File.WriteAllText(outputpath, output);
            }
        }
        #endregion

        #region 生成Android代码
        private void RenderJFragmentFile(TableModel mo)
        {

            if (!Directory.Exists(_outputPath + "Fragment\\"))
            {
                Directory.CreateDirectory(_outputPath + "Fragment\\");
            }
            var entityOutputPath = _outputPath + "Fragment\\" + mo.Code +
                                   "Fragment.java";
            var fragmentTemplate = new J_FragmentTemplate(mo, _projectName, _package);
            var fragmentoutput = fragmentTemplate.TransformText();
            File.WriteAllText(entityOutputPath, fragmentoutput);
        }
        private void RenderJLayoutFile(TableModel mo)
        {

            if (!Directory.Exists(_layoutPath + "layout\\"))
            {
                Directory.CreateDirectory(_layoutPath + "layout\\");
            }
            var entityOutputPath = _layoutPath + "layout\\" + mo.Code.ToLower() +
                                   ".xml";
            var layoutTemplate = new J_LayoutTemplate(mo, mo.Code, _package);
            var layoutoutput = layoutTemplate.TransformText();
            File.WriteAllText(entityOutputPath, layoutoutput);
        }

        private void RenderJLayoutItemFile(TableModel mo)
        {

            if (!Directory.Exists(_layoutPath + "layout\\"))
            {
                Directory.CreateDirectory(_layoutPath + "layout\\");
            }
            var entityOutputPath = _layoutPath + "layout\\" + mo.Code.ToLower() +
                                   "_item.xml";
            var layoutTemplate = new J_LayoutItemTemplate(mo, mo.Code, _package);
            var layoutoutput = layoutTemplate.TransformText();
            File.WriteAllText(entityOutputPath, layoutoutput);


            var listentityOutputPath = _layoutPath + "layout\\" + mo.Code.ToLower() +
                                   "_listitem.xml";
            var listlayoutTemplate = new J_LayoutListItemTemplate(mo, mo.Code, _package);
            var listlayoutoutput = listlayoutTemplate.TransformText();
            File.WriteAllText(listentityOutputPath, listlayoutoutput);


        }

        private void RenderJDataViewMainFile(List<TableModel> mo)
        {

            if (!Directory.Exists(_outputPath + "Fragment\\"))
            {
                Directory.CreateDirectory(_outputPath + "Fragment\\");
            }
            var entityOutputPath = _outputPath + "Fragment\\DataViewFragment.java";
            var layoutTemplate = new J_DataViewMainTemplate(mo, _projectName, _package);
            var layoutoutput = layoutTemplate.TransformText();
            File.WriteAllText(entityOutputPath, layoutoutput);
        }

        private void RenderJDataViewMainEventFile(List<TableModel> mo)
        {

            if (!Directory.Exists(_outputPath + "Event\\"))
            {
                Directory.CreateDirectory(_outputPath + "Event\\");
            }
            var entityOutputPath = _outputPath + "Event\\DataViewEvent.java";
            var layoutTemplate = new J_DataViewMainEventTemplate(mo, _projectName, _package);
            var layoutoutput = layoutTemplate.TransformText();
            File.WriteAllText(entityOutputPath, layoutoutput);
        }

        private void RenderJEventMainFile(List<TableModel> mo)
        {

            if (!Directory.Exists(_outputPath + "Event\\"))
            {
                Directory.CreateDirectory(_outputPath + "Event\\");
            }
            var entityOutputPath = _outputPath + "Event\\" + _projectName.ToLower() +
                                   "Event.java";
            var layoutTemplate = new J_EventMainTemplate(mo, _projectName, _package);
            var layoutoutput = layoutTemplate.TransformText();
            File.WriteAllText(entityOutputPath, layoutoutput);
        }

        private void RenderJLayoutMainFile(List<TableModel> mo)
        {

            if (!Directory.Exists(_layoutPath + "layout\\"))
            {
                Directory.CreateDirectory(_layoutPath + "layout\\");
            }
            var entityOutputPath = _layoutPath + "layout\\" + _projectName.ToLower() +
                                   ".xml";
            var layoutTemplate = new J_LayoutMainTemplate(mo, _projectName, _package);
            var layoutoutput = layoutTemplate.TransformText();
            File.WriteAllText(entityOutputPath, layoutoutput);
        }

        private void RenderJEventFile(TableModel mo, List<TableModel> data)
        {

            if (!Directory.Exists(_outputPath + "Event\\"))
            {
                Directory.CreateDirectory(_outputPath + "Event\\");
            }
            var eventOutputPath = _outputPath + "Event\\" + mo.Code + "Event.java";
            var eventTemplate = new J_EventTemplate(mo, _projectName, _package, data);
            var eventoutput = eventTemplate.TransformText();
            File.WriteAllText(eventOutputPath, eventoutput);
        }

        private void RenderJAdapterFile(TableModel mo)
        {

            if (!Directory.Exists(_outputPath + "Adapter\\"))
            {
                Directory.CreateDirectory(_outputPath + "Adapter\\");
            }
            var AdapterOutputPath = _outputPath + "Adapter\\" + mo.Code + "Adapter.java";
            var AdapterTemplate = new J_AdapterTemplate(mo, _projectName, _package);
            var Adapteroutput = AdapterTemplate.TransformText();
            File.WriteAllText(AdapterOutputPath, Adapteroutput);


            var ListAdapterOutputPath = _outputPath + "Adapter\\" + mo.Code + "ListAdapter.java";
            var ListAdapterTemplate = new J_AdapterListTemplate(mo, _projectName, _package);
            var ListAdapteroutput = ListAdapterTemplate.TransformText();
            File.WriteAllText(ListAdapterOutputPath, ListAdapteroutput);

            var RecycleAdapterOutputPath = _outputPath + "Adapter\\Recycle" + mo.Code + "Adapter.java";
            var RecycleAdapterTemplate = new J_RecycleAdapterTemplate(mo, _projectName, _package);
            var RecycleAdapteroutput = RecycleAdapterTemplate.TransformText();
            File.WriteAllText(RecycleAdapterOutputPath, RecycleAdapteroutput);

        }
        private void RenderJModelFile(TableModel mo, List<TableModel> da)
        {
            if (!Directory.Exists(_outputPath + "Model\\"))
            {
                Directory.CreateDirectory(_outputPath + "Model\\");
            }
            var entityOutputPath = _outputPath + "Model\\" + mo.Code +
                                   "Model.java";
            var modelTemplate = new J_ModelTemplate(mo, mo.Code, _package, da);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }


        private void RenderJViewModelFile(TableModel mo, List<TableModel> ao)
        {
            if (!Directory.Exists(_outputPath + "ViewModel\\"))
            {
                Directory.CreateDirectory(_outputPath + "ViewModel\\");
            }
            var entityOutputPath = _outputPath + "ViewModel\\" + mo.Code +
                                   "ViewModel.java";
            var modelTemplate = new J_ViewModelTemplate(mo, mo.Code, _package, ao, _projectName);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }
        private void RenderJModelListFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Model\\"))
            {
                Directory.CreateDirectory(_outputPath + "Model\\");
            }
            var entityOutputPath = _outputPath + "Model\\" + mo.Code +
                                   "List.java";
            var modelTemplate = new J_ModelListTemplate(mo, mo.Code, _package);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }

        private void RenderJDialogFile()
        {
            if (!Directory.Exists(_outputPath + "Dialog\\"))
            {
                Directory.CreateDirectory(_outputPath + "Dialog\\");
            }
            var myAlertDialogPath = _outputPath + "Dialog\\ListViewDialog.java";
            var myAlertDialog = new J_ListViewDialogTemplate(_projectName, _package);
            var myAlertDialogoutput = myAlertDialog.TransformText();
            File.WriteAllText(myAlertDialogPath, myAlertDialogoutput);

            var myDialogPath = _outputPath + "Dialog\\MyDialog.java";
            var myDialog = new J_MyDialogTemplate(_projectName, _package);
            var myDialogoutput = myDialog.TransformText();
            File.WriteAllText(myDialogPath, myDialogoutput);


            //var myLoadingDialogPath = _outputPath + "Dialog\\MyLoadingDialog.java";
            //var myLoadingDialog = new J_MyLoadingDialogTemplate(_projectName, _package);
            //var myLoadingDialogoutput = myLoadingDialog.TransformText();
            //File.WriteAllText(myLoadingDialogPath, myLoadingDialogoutput);
        }


        private void RenderJCommonFile()
        {
            if (!Directory.Exists(_outputPath + "Common\\"))
            {
                Directory.CreateDirectory(_outputPath + "Common\\");
            }

            var dialogUtilPath = _outputPath + "Common\\DialogUtil.java";
            var dialogUtil = new J_DialogUtilTemplate(_projectName, _package);
            var dialogUtiloutput = dialogUtil.TransformText();
            File.WriteAllText(dialogUtilPath, dialogUtiloutput);

            //var loadingUtilPath = _outputPath + "Common\\LoadingUtil.java";
            //var loadingUtil = new J_LoadingUtilTemplate(_projectName, _package);
            //var loadingUtiloutput = loadingUtil.TransformText();
            //File.WriteAllText(loadingUtilPath, loadingUtiloutput);

            var loadUtilPath = _outputPath + "Common\\LoadUtil.java";
            var loadUtil = new J_LoadUtilTemplate(_projectName, _package);
            var loadUtiloutput = loadUtil.TransformText();
            File.WriteAllText(loadUtilPath, loadUtiloutput);

            var toastUtilPath = _outputPath + "Common\\ToastUtil.java";
            var toastUtil = new J_ToastUtilTemplate(_projectName, _package);
            var toastUtiloutput = toastUtil.TransformText();
            File.WriteAllText(toastUtilPath, toastUtiloutput);

            var UtilPath = _outputPath + "Common\\Util.java";
            var Util = new J_UtilTemplate(_package);
            var Utiloutput = Util.TransformText();
            File.WriteAllText(UtilPath, Utiloutput);



        }

        private void RenderJBaseFile(List<TableModel> mo)
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var entityOutputPath = _outputPath + "Base\\BaseMsg.java";
            var jBaseMsg = new J_BaseMsgTemplate(_package);
            var output = jBaseMsg.TransformText();
            File.WriteAllText(entityOutputPath, output);

            var AddCookieentityOutputPath = _outputPath + "Base\\AddCookiesInterceptor.java";
            var jAddCookie = new J_AddCookieTemplate(_package);
            var AddCookieoutput = jAddCookie.TransformText();
            File.WriteAllText(AddCookieentityOutputPath, AddCookieoutput);

            var ReciveCookieentityOutputPath = _outputPath + "Base\\ReceivedCookiesInterceptor.java";
            var jReciveCookie = new J_ReciveCookieTemplate(_package);
            var ReciveCookieoutput = jReciveCookie.TransformText();
            File.WriteAllText(ReciveCookieentityOutputPath, ReciveCookieoutput);


            var jBaseResponsePath = _outputPath + "Base\\BaseResponse.java";
            var jBaseResponse = new J_BaseResponseTemplate(_package);
            var jBaseResponseoutput = jBaseResponse.TransformText();
            File.WriteAllText(jBaseResponsePath, jBaseResponseoutput);

            var baseSubscriberPath = _outputPath + "Base\\BaseSubscriber.java";
            var baseSubscriber = new J_BaseSubscriberTemplate(_package);
            var baseSubscriberoutput = baseSubscriber.TransformText();
            File.WriteAllText(baseSubscriberPath, baseSubscriberoutput);

            var defaultTransformerPath = _outputPath + "Base\\DefaultTransformer.java";
            var defaultTransformer = new J_DefaultTransformerTemplate(_package);
            var defaultTransformeroutput = defaultTransformer.TransformText();
            File.WriteAllText(defaultTransformerPath, defaultTransformeroutput);

            var dialogSubscriberPath = _outputPath + "Base\\DialogSubscriber.java";
            var dialogSubscriber = new J_DialogSubscriberTemplate(_package);
            var dialogSubscriberoutput = dialogSubscriber.TransformText();
            File.WriteAllText(dialogSubscriberPath, dialogSubscriberoutput);


            var errorCheckerTransformerPath = _outputPath + "Base\\ErrorCheckerTransformer.java";
            var errorCheckerTransformer = new J_ErrorCheckerTransformerTemplate(_package);
            var errorCheckerTransformeroutput = errorCheckerTransformer.TransformText();
            File.WriteAllText(errorCheckerTransformerPath, errorCheckerTransformeroutput);

            var errorResponseExceptionPath = _outputPath + "Base\\ErrorResponseException.java";
            var errorResponseException = new J_ErrorResponseExceptionTemplate(_package);
            var errorResponseExceptionoutput = errorResponseException.TransformText();
            File.WriteAllText(errorResponseExceptionPath, errorResponseExceptionoutput);

            var msgPath = _outputPath + "Base\\Msg.java";
            var msg = new J_MsgTemplate(_package);
            var msgoutput = msg.TransformText();
            File.WriteAllText(msgPath, msgoutput);

            var mySubscriberPath = _outputPath + "Base\\MySubscriber.java";
            var mySubscriber = new J_MySubscriberTemplate(_package);
            var mySubscriberoutput = mySubscriber.TransformText();
            File.WriteAllText(mySubscriberPath, mySubscriberoutput);


            var noneDataTransformerPath = _outputPath + "Base\\NoneDataTransformer.java";
            var noneDataTransformer = new J_NoneDataTransformerTemplate(_package);
            var noneDataTransformeroutput = noneDataTransformer.TransformText();
            File.WriteAllText(noneDataTransformerPath, noneDataTransformeroutput);

            var schedulerTransformerPath = _outputPath + "Base\\SchedulerTransformer.java";
            var schedulerTransformer = new J_SchedulerTransformerTemplate(_package);
            var schedulerTransformeroutput = schedulerTransformer.TransformText();
            File.WriteAllText(schedulerTransformerPath, schedulerTransformeroutput);

            var serviceFactoryPath = _outputPath + "Base\\ServiceFactory.java";
            var serviceFactory = new J_ServiceFactoryTemplate(_package);
            var serviceFactoryoutput = serviceFactory.TransformText();
            File.WriteAllText(serviceFactoryPath, serviceFactoryoutput);

            var toastSubscriberPath = _outputPath + "Base\\ToastSubscriber.java";
            var toastSubscriber = new J_ToastSubscriberTemplate(_package);
            var toastSubscriberoutput = toastSubscriber.TransformText();
            File.WriteAllText(toastSubscriberPath, toastSubscriberoutput);


            var dbOpenHelperPath = _outputPath + "Base\\DBOpenHelper.java";
            var dbOpenHelper = new J_DBOpenHelperTemplate(_package, mo);
            var dbOpenHelperoutput = dbOpenHelper.TransformText();
            File.WriteAllText(dbOpenHelperPath, dbOpenHelperoutput);


            var appManagerPath = _outputPath + "Base\\AppManager.java";
            var appManager = new J_AppManageTemplate(_projectName, _package);
            var appManageroutput = appManager.TransformText();
            File.WriteAllText(appManagerPath, appManageroutput);


            var PageListPath = _outputPath + "Base\\PageList.java";
            var PageList = new J_PageListTemplate(_package);
            var PageListoutput = PageList.TransformText();
            File.WriteAllText(PageListPath, PageListoutput);




            RenderJManageFile();
            RenderJAESCryptoFile();
            RenderJResponseFile();

        }
        private void RenderJManageFile()
        {
            if (!Directory.Exists(_outputPath + "Manage\\"))
            {
                Directory.CreateDirectory(_outputPath + "Manage\\");
            }
            var retrofitManagerPath = _outputPath + "Manage\\RetrofitManager.java";
            var retrofitManager = new J_RetrofitManagerTemplate(_package);
            var output = retrofitManager.TransformText();
            File.WriteAllText(retrofitManagerPath, output);
        }

        private void RenderJResponseFile()
        {
            if (!Directory.Exists(_outputPath + "Response\\"))
            {
                Directory.CreateDirectory(_outputPath + "Response\\");
            }
            var msgResponsePath = _outputPath + "Response\\MsgResponse.java";
            var msgResponse = new J_MsgResponseTemplate(_package);
            var msgResponseoutput = msgResponse.TransformText();
            File.WriteAllText(msgResponsePath, msgResponseoutput);

            var noneDataResponsePath = _outputPath + "Response\\NoneDataResponse.java";
            var noneDataResponse = new J_NoneDataResponseTemplate(_package);
            var noneDataResponseoutput = noneDataResponse.TransformText();
            File.WriteAllText(noneDataResponsePath, noneDataResponseoutput);
        }
        private void RenderJDataFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Data\\"))
            {
                Directory.CreateDirectory(_outputPath + "Data\\");
            }
            var entityOutputPath = _outputPath + "Data\\" + mo.Code +
                                   "DAO.java";
            var daoTemplate = new J_DAOTemplate(_package, mo.Code, mo);
            var output = daoTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }

        private void RenderJAESCryptoFile()
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var aesCryptoPath = _outputPath + "Base\\" + "AESCrypto.java";
            var aesCrypto = new J_AESCryptoTemplate(_package);
            var aesCryptooutput = aesCrypto.TransformText();
            File.WriteAllText(aesCryptoPath, aesCryptooutput);
        }


        private void RenderJIServiceFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "IService\\"))
            {
                Directory.CreateDirectory(_outputPath + "IService\\");
            }
            var entityOutputPath = _outputPath + "IService\\I" + mo.Code +
                                   "Service.java";
            var modelTemplate = new J_IServiceTemplate(_package, mo.Code, mo);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }

        private void RenderJServiceFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Service\\"))
            {
                Directory.CreateDirectory(_outputPath + "Service\\");
            }
            var entityOutputPath = _outputPath + "Service\\" + mo.Code +
                                   "Service.java";
            var modelTemplate = new J_ServiceTemplate(_package, mo.Code, mo);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }

        //private void RenderBllFile(TableModel mo)
        //{
        //    if (!Directory.Exists(_outputPath + "BLL\\" + mo.Code + "\\"))
        //    {
        //        Directory.CreateDirectory(_outputPath + "BLL\\" + mo.Code + "\\");
        //    }
        //    var entityOutputPath = _outputPath + "BLL\\" + mo.Code + "\\" + mo.Code +
        //                           "BLL.cs";
        //    var modelTemplate = new NewBLLTemplate(_projectName, mo);
        //    var output = modelTemplate.TransformText();
        //    File.WriteAllText(entityOutputPath, output);
        //}

        #endregion

        #region 生成Ado代码
        private void RenderNewModelFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Model\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Model\\" + mo.Code + "\\");
            }
            var entityOutputPath = _outputPath + "Model\\" + mo.Code + "\\" + mo.Code +
                                   "Model.cs";
            var modelTemplate = new NewModelTemplate(_projectName, mo);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);

            if (!Directory.Exists(_outputPath + "Model\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Model\\" + mo.Code + "\\");
            }
            var searchConditionOut = _outputPath + "Model\\" + mo.Code + "\\" + mo.Code +
                                   "SearchCondition.cs";
            var searchConditionTemplate = new NewConditionTemplate(mo.ColumnsList, mo.Code, _projectName);
            var searchCondition = searchConditionTemplate.TransformText();
            File.WriteAllText(searchConditionOut, searchCondition);
        }

        private void RenderNewIServiceFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "IDAL\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "IDAL\\" + mo.Code + "\\");
            }
            var entityOutputPath = _outputPath + "IDAL\\" + mo.Code + "\\I" + mo.Code +
                                   "DAL.cs";
            var modelTemplate = new NewIServiceTemplate(_projectName, mo);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }

        private void RenderNewServiceFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "DAL\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "DAL\\" + mo.Code + "\\");
            }
            var entityOutputPath = _outputPath + "DAL\\" + mo.Code + "\\" + mo.Code +
                                   "DAL.cs";
            var modelTemplate = new NewServiceTemplate(_projectName, mo, _options);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }
        public static string WriteDALText(TableModel mo, DataBaseType type)
        {
            var modelTemplate = new NewServiceTemplate(mo.Code, mo, new SaveOptions { DataBaseType = type });
            return modelTemplate.TransformText();
        }
        public static string WriteModelText(TableModel mo, DataBaseType type)
        {
            var modelTemplate = new NewModelTemplate(mo.Code, mo);
            return modelTemplate.TransformText();
        }
        public static string WriteBLLText(TableModel mo, DataBaseType type)
        {
            var modelTemplate = new NewBLLTemplate(mo.Code, mo);
            return modelTemplate.TransformText();
        }

        private void RenderNewBllFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "BLL\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "BLL\\" + mo.Code + "\\");
            }
            var entityOutputPath = _outputPath + "BLL\\" + mo.Code + "\\" + mo.Code +
                                   "BLL.cs";
            var modelTemplate = new NewBLLTemplate(_projectName, mo);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }

        #endregion

        #region 生成CodeFirst代码
        private void RenderEntityFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Entity\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Entity\\" + mo.Code + "\\");
            }
            var entityOutputPath = _outputPath + "Entity\\" + mo.Code + "\\" + mo.Code +
                                   "Entity.cs";
            var modelTemplate = new ModelTemplate(mo, mo.Code, _projectName);
            var output = modelTemplate.TransformText();
            File.WriteAllText(entityOutputPath, output);
        }
        public void RenderSqlFunctionFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Base\\SqlFunction\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\SqlFunction\\");
            }
            var sqlFunctionOutputPath = _outputPath + "Base\\SqlFunction\\" + mo.Code +
                                   ".cs";
            var sqlFunctionTemplate = new SqlFunctionTemplate(mo, mo.Code, _projectName);
            var output = sqlFunctionTemplate.TransformText();
            File.WriteAllText(sqlFunctionOutputPath, output);
        }
        public void RenderMappingFile(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Mappings\\" + models.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Mappings\\" + models.Code + "\\");
            }
            var outputPath = _outputPath + "Mappings\\" + models.Code + "\\" + models.Code + "Mapping.cs";
            var mappingTemplate = new MappingTemplate(models, _projectName, models.Code, _mapText, _options);
            var output = mappingTemplate.TransformText();
            File.WriteAllText(outputPath, output);
        }

        public void RenderEnumFile(List<EnumModel> models)
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var enumTemplate = new EnumTemplate(models, _projectName);
            var output = enumTemplate.TransformText();
            var outputPath = _outputPath + "Base\\" + _projectName + "_E.cs";
            File.WriteAllText(outputPath, output);
        }
        public void RenderConfigurationFile(List<TableModel> models)
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var configurationTemplate = new ConfigurationTemplate(models, _projectName, _options);
            var configurationoutput = configurationTemplate.TransformText();
            var configurationoutputPath = _outputPath + "Base\\" + _projectName + "Configuration.cs";
            File.WriteAllText(configurationoutputPath, configurationoutput);
        }




        public void RenderBaseDataFile()
        {
            if (!Directory.Exists(_outputPath + "Base\\"))
            {
                Directory.CreateDirectory(_outputPath + "Base\\");
            }
            var mappingTemplate = new IMappingTemplate(_projectName);
            var mappingoutput = mappingTemplate.TransformText();
            var mappingoutputPath = _outputPath + "Base\\I" + _projectName + "Mapping.cs";
            File.WriteAllText(mappingoutputPath, mappingoutput);

            var repositoryTemplate = new IRepositoryTemplate(_projectName, _options);
            var repositoryoutput = repositoryTemplate.TransformText();
            var repositoryoutputPath = _outputPath + "Base\\I" + _projectName + "Repository.cs";
            File.WriteAllText(repositoryoutputPath, repositoryoutput);

            var dbContextTemplate = new DbContextTemplate(_projectName, _options);
            var dbContextoutput = dbContextTemplate.TransformText();
            var dbContextoutputPath = _outputPath + "Base\\" + _projectName + "DbContext.cs";
            File.WriteAllText(dbContextoutputPath, dbContextoutput);

            var RepositoryTemplate = new RepositoryTemplate(_projectName, _options);
            var Repositoryoutput = RepositoryTemplate.TransformText();
            var RepositoryoutputPath = _outputPath + "Base\\" + _projectName + "Repository.cs";
            File.WriteAllText(RepositoryoutputPath, Repositoryoutput);


            var IBaseContextTemplate = new IBaseContextTemplate(_projectName);
            var IBaseContextoutput = IBaseContextTemplate.TransformText();
            var IBaseContextoutputPath = _outputPath + "Base\\I" + _projectName + "Context.cs";
            File.WriteAllText(IBaseContextoutputPath, IBaseContextoutput);


            var DepencyTemplate = new DepencyTemplate(_projectName, _options);
            var DepencyTemplateoutput = DepencyTemplate.TransformText();
            var BaseContextoutputPath = _outputPath + "Base\\" + _projectName + "Depency.cs";
            File.WriteAllText(BaseContextoutputPath, DepencyTemplateoutput);

        }
        public void RenderSearchFile(TableModel mo)
        {
            if (!Directory.Exists(_outputPath + "Entity\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Entity\\" + mo.Code + "\\");
            }
            var searchTemplate = new ConditionTemplate(mo.ColumnsList, mo.Code, _projectName);
            var output = searchTemplate.TransformText();
            var outputPath = _outputPath + "Entity\\" + mo.Code + "\\" + mo.Code +
                             "SearchConditon.cs";
            File.WriteAllText(outputPath, output);
        }

        public void RenderServiceFile(TableModel mo, List<TableModel> AllModes)
        {
            if (!Directory.Exists(_outputPath + "Service\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Service\\" + mo.Code + "\\");
            }
            var serviceTemplate = new ServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            var output = serviceTemplate.TransformText();
            var outputPath = _outputPath + "Service\\" + mo.Code + "\\" + mo.Code + "Service.cs";
            File.WriteAllText(outputPath, output);

            var interfaceTemplate = new IServiceTemplate(_projectName, mo.Code, mo, _pro);
            var iOutPut = interfaceTemplate.TransformText();
            var iOutPutPath = _outputPath + "Service\\" + mo.Code + "\\I" + mo.Code +
                              "Service.cs";
            File.WriteAllText(iOutPutPath, iOutPut);
        }

        public void RenderBaseServiceFile(TableModel mo, List<TableModel> AllModes)
        {
            if (!Directory.Exists(_outputPath + "BaseService\\"))
            {
                Directory.CreateDirectory(_outputPath + "BaseService\\");
            }
            var baseServiceTemplate = new BaseServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            var output = baseServiceTemplate.TransformText();
            var outputPath = _outputPath + "BaseService\\" + mo.Code + "BaseService.cs";
            File.WriteAllText(outputPath, output);

            var interfaceTemplate = new IBaseServiceTemplate(_projectName, mo.Code, mo, _pro);
            var iOutPut = interfaceTemplate.TransformText();
            var iOutPutPath = _outputPath + "BaseService\\I" + mo.Code +
                              "BaseService.cs";
            File.WriteAllText(iOutPutPath, iOutPut);
        }
        public void RenderChangeServiceFile(TableModel mo, List<TableModel> AllModes)
        {
            if (!Directory.Exists(_outputPath + "ChangeService\\" + mo.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "ChangeService\\" + mo.Code + "\\");
            }
            var changeServiceTemplate = new ChangeServiceTemplate(_projectName, mo.Code.Replace("_", ""), mo.ColumnsList, mo, _repositoryText, _pro, _options, AllModes);
            var output = changeServiceTemplate.TransformText();
            var outputPath = _outputPath + "ChangeService\\" + mo.Code + "\\" + mo.Code + "ChangeService.cs";
            var Oldpath = _outputPath + "ChangeService\\" + mo.Code + "\\" + mo.Code +
                               "ChangeService_Old.cs";

            if (File.Exists(outputPath))
            {
                if (!File.Exists(Oldpath))
                    File.Move(outputPath, Oldpath);
            }
            File.WriteAllText(outputPath, output);

            var interfaceChange = new IChangeServiceTemplate(_projectName, mo.Code, mo, _pro);
            var iOutPut = interfaceChange.TransformText();
            var iOutPutPath = _outputPath + "ChangeService\\" + mo.Code + "\\I" + mo.Code +
                              "ChangeService.cs";


            File.WriteAllText(iOutPutPath, iOutPut);
        }

        public void RenderControllerFile(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Controllers\\" + _projectName + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Controllers\\" + _projectName + "\\");
            }
            var controllerTemplate = new ControllerTemplate(models, models.Code, _projectName, _apiName, _repositoryText, _pro);
            var output = controllerTemplate.TransformText();
            var outputpath = _outputPath + "Controllers\\" + _projectName + "\\" + models.Code + "Controller.cs";
            File.WriteAllText(outputpath, output);
        }

        public void RenderControllerUIFile(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Controllers\\"))
            {
                Directory.CreateDirectory(_outputPath + "Controllers\\");
            }
            var controllerTemplate = new T_LigerUI.ControllerTemplate(models, models.Code, _projectName, _apiName, _pro);
            var output = controllerTemplate.TransformText();
            var outputpath = _outputPath + "Controllers\\" + _projectName + models.Code + "Controller.cs";
            File.WriteAllText(outputpath, output);
        }
        public void RenderControllerViewFile(TableModel models, List<TableModel> mo)
        {
            if (!Directory.Exists(_outputPath + "Views2\\" + _projectName + models.Code + "\\"))
            {
                Directory.CreateDirectory(_outputPath + "Views2\\" + _projectName + models.Code + "\\");
            }
            var viewTemplate = new T_LigerUI.ViewTemplate(models, models.Code, _projectName, _apiName, _pro);
            var output = viewTemplate.TransformText();
            var outputpath = _outputPath + "Views2\\" + _projectName + models.Code + "\\Index.cshtml";
            File.WriteAllText(outputpath, output);

            var EditTemplate = new T_LigerUI.EditTemplate(models, models.Code, _projectName, _apiName, _pro, mo);
            var Editoutput = EditTemplate.TransformText();
            var Editoutputpath = _outputPath + "Views2\\" + _projectName + models.Code + "\\Edit.cshtml";
            File.WriteAllText(Editoutputpath, Editoutput);
        }

        public void RenderViewModel(TableModel models)
        {
            if (!Directory.Exists(_outputPath + "Models\\"))
            {
                Directory.CreateDirectory(_outputPath + "Models\\");
            }
            var controllerTemplate = new ViewModelTemplate(models, models.Code, _projectName);
            var output = controllerTemplate.TransformText();
            var outputpath = _outputPath + "Models\\" + models.Code + "Model.cs";
            File.WriteAllText(outputpath, output);
        }
        #endregion

    }
}
