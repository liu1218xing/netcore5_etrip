(function () {
    
    app.modals.CreateOrEditAreaModal = function () {

        var _modalManager;
        var _areaService = abp.services.app.area;
        var _$form = null;

        
        
        this.init = function (modalManager) {
            _modalManager = modalManager;
            abp.log.debug("-----------getmodel-----------");
            abp.log.debug(_modalManager.getModal());
            _$form = _modalManager.getModal().find('form[name=AreaForm]');
            abp.log.debug("-----------form-----------");
            abp.log.debug(_areaService);

            //$.ajax({
            //    url: abp.appPath + "api/services/app/SimpleTask/GetAllTasks",
            //    type: 'GET'
            //}).done(function (data) {
            //    abp.log.debug("--------------------");
            //    abp.log.debug(data);
            //});
            //$.ajax({
            //    url: abp.appPath + "api/services/app/Area/GetValidateAreaId",
            //    type: 'GET',
            //    dataType: "json",
            //    data: {                        //要传递的数据
            //        AreaId: function () {
            //            return "440000";
            //        }
            //    }
            //}).done(function (data) {
            //    abp.log.debug("--------------------");
            //    abp.log.debug(data);
            //});
            //abp.log.debug("--------3333333333333------------");
            //abp.log.debug(_$form.serializeFormToObject());
            //$.ajax({
            //    url: abp.appPath + "api/services/app/Area/GetValidAreaIdOrName",
            //    type: 'GET',
            //    dataType: "json",
            //    data: {                        //要传递的数据
            //        AreaEdit: function () {
            //            return _$form.serializeFormToObject();
            //        }
            //    }
            //}).done(function (data) {
            //    abp.log.debug("--------------------");
            //    abp.log.debug(data.result);
            //});

            //var areaValidate = _$form.serializeFormToObject();
            //abp.log.debug(areaValidate);
            //_areaService.getValidAreaIdOrName({
            //    areaEdit: areaValidate
            //}).done(function (data) {
            //    abp.log.debug(data);
            //    });

            
            //abp.log.debug(areaValidate);
            //_areaService.getValidateAreaId({
            //    areaId: "440000"
            //}).done(function (data) {
            //    abp.log.debug(data);
            //});

            //验证表单
            
            _$form.validate({
                rules: {
                    AreaName: {
                        required: true
                    }, AreaId: {
                        required: true
                        //,
                        //remote: {
                        //    url: abp.appPath + "api/services/app/Area/GetValidAreaIdOrName",     //后台处理程序
                        //    type: "get",                   //数据发送方式
                        //    dataType: "json",              //接受数据格式   
                        //    data: {                        //要传递的数据
                        //        AreaEdit: function () {
                        //            return _$form.serializeFormToObject();
                        //        }
                        //    }
                        //}
                    }
                },
                messages: {
                    
                    AreaId: {
                        required: "必填"
                        //,
                        //remote: "该用户名已存在！"
                    }, AreaName: {
                        required: "必填"
                    }
                }
            })

            //_$form.validate({ ignore: "" });
        };
        
        this.save = function () {
            if (!_$form.valid()) {
                return;
            }

            var area = _$form.serializeFormToObject();
            abp.log.debug("-----------area-----------");
            abp.log.debug(area);
            abp.log.debug(_areaService);
            _modalManager.setBusy(true);
            _areaService.createOrUpdateArea({
                areaEdit: area
            }
            ).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditAreaModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();