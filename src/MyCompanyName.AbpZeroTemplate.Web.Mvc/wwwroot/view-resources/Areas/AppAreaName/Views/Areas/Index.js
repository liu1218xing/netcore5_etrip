(function () {
    $(function () {

        var _$AreasTable = $('#AreasTable');
        var _AreaService = abp.services.app.area;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Areas.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Areas.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Areas.Delete')
        };

        var _createModal = new app.ModalManager({
            viewUrl: abp.appPath + 'AppAreaName/Areas/CreateModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/Areas/_CreateModal.js',
            modalClass: 'CreateAreaModal'
        });

        function deleteArea(Area) {
            abp.message.confirm(
                app.localize('AreaDeleteWarningMessage', Area.areaName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _AreaService.deleteArea({
                            id: Area.id
                        }).done(function () {
                            getAreas();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewAreaButton').click(function () {
            _createModal.open();
        });

        abp.event.on('app.createAreaModalSaved', function () {
            getAreas();
        });
        abp.log.debug(_AreaService);
        _AreaService.getAreas().done(function (data) {
            abp.log.debug(data);
        });
        abp.log.debug(_AreaService.getAreas);
        var dataTable = _$AreasTable.DataTable({
            paging: false,
            listAction: {
                ajaxFunction: _AreaService.getAreas
            },
            columnDefs: [
                {
                    targets: 0,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        cssClass: 'btn btn-xs btn-primary blue',
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
                            {
                                text: app.localize('Edit'),
                                visible: function () {
                                    return _permissions.edit;
                                },
                                action: function (data) {
                                    _createModal.open({ id: data.record.id });
                                }
                            }, {
                                text: app.localize('Delete'),
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteArea(data.record);
                                }
                            }
                        ]
                    }
                },
                {
                    targets: 1,
                    data: "areaId"
                },
                {
                    targets: 2,
                    data: "areaName"
                },
                {
                    targets: 3,
                    data: "areaDescription"
                },
                {
                    targets: 4,
                    data: "creationTime",
                    render: function (creationTime) {
                        return moment(creationTime).format('L');
                    }
                }
            ]
        });

        function getAreas() {
            dataTable.ajax.reload();
        }
    });
})();