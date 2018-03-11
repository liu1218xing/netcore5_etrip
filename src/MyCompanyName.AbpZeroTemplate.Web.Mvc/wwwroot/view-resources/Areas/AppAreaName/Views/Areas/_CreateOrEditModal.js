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
            $.ajax({
                url: abp.appPath + "api/services/app/Area/GetValidateAreaIdString",
                type: 'GET',
                dataType: "json",
                data: {                        //要传递的数据
                    AreaId: function () {
                        return "440000";
                    }
                }
            }).done(function (data) {
                abp.log.debug("--------------------");
                abp.log.debug(data.result);
            });
            
            //_areaService.validAreaIdOrNameS({
            //    AreaId: "440000"
            //}
            //).done(function (data) {
            //    abp.log.debug(data);
            //});

            //var areaValidate = _$form.serializeFormToObject();
            //_areaService.validAreaIdOrName({
            //    areaEdit: areaValidate
            //}).done(function (data) {
            //    abp.log.debug(data);
            //})
            

            //验证表单
            
            _$form.validate({
                rules: {
                    
                     AreaName: {
                        required: true
                    }
                    
                },
                messages: {
                    
                    AreaId: {
                        required: "必填",
                        remote: "该用户名已存在！"
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