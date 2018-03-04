(function () {
    $(function () {

        var _$SimpleTasksTable = $('#SimpleTasksTable');
        var _simpleTaskService = abp.services.app.simpleTask;
        var _permissions = {
            create: abp.auth.hasPermission('Pages.SimpleTasks.Create'),
            edit: abp.auth.hasPermission('Pages.SimpleTasks.Edit'),
            'delete': abp.auth.hasPermission('Pages.SimpleTasks.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'AppAreaName/SimpleTasks/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/SimpleTasks/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditSimpleTaskModal'
        });

        function deleteSimpleTask(SimpleTask) {
            abp.message.confirm(
                app.localize('SimpleTaskDeleteWarningMessage', SimpleTask.displayName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _SimpleTaskService.deleteSimpleTask({
                            id: SimpleTask.id
                        }).done(function () {
                            getSimpleTasks();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewSimpleTaskButton').click(function () {
            _createOrEditModal.open();
        });

        abp.event.on('app.createOrEditSimpleTaskModalSaved', function () {
            getSimpleTasks();
        });
        abp.log.debug(_simpleTaskService.getAllTasks);
        //$.ajax({
        //    url: abp.appPath + _simpleTaskService.getAllTasks.url,
        //    type: 'GET'
        //}).done(function (data) {
           
        //    abp.log.debug(data);
        //    });

        _simpleTaskService.getAllTasks().done(function (data) {
            abp.log.debug(data);
        });
        abp.log.debug(_$SimpleTasksTable);
        var dataTable = _$SimpleTasksTable.DataTable({
            paging: false,
            listAction: {
                ajaxFunction: _simpleTaskService.getAllTasks
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
                                    _createOrEditModal.open({ id: data.record.id });
                                }
                            }, {
                                text: app.localize('Delete'),
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteSimpleTask(data.record);
                                }
                            }
                        ]
                    }
                },
                {
                    targets: 1,
                    data: "title"
                },
                {
                    targets: 2,
                    data: "description"
                },
                {
                    targets: 3,
                    data: "assignedPersonName"
                },
                {
                    targets: 4,
                    data: "state"
                },
                
                {
                    targets: 5,
                    data: "creationTime",
                    render: function (creationTime) {
                        return moment(creationTime).format('L');
                    }
                }
            ]
        });

        function getSimpleTasks() {
            dataTable.ajax.reload();
        }
    });
})();