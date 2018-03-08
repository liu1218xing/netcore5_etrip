(function () {
  
    app.modals.CreateAreaModal = function () {

        var _modalManager;
        var _areaService = abp.services.app.area;
        var _$form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            abp.log.debug("-----------getmodel-----------");
            abp.log.debug(_modalManager.getModal());
            _$form = _modalManager.getModal().find('form[name=AreaForm]');
            abp.log.debug("-----------form-----------");
            abp.log.debug(_$form);
            _$form.validate({ ignore: "" });
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
            _areaService.createOrUpdateArea(
                area
            ).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                
                _modalManager.close();
                abp.event.trigger('app.createAreaModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();