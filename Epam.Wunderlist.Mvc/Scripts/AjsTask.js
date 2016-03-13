angular.module('AngularJS').service('myService', function () {

    this.id;
    this.taskList;
    
});

angular.module('AngularJS').controller('ModalTaskCtrl', function ($scope, $uibModalInstance, $http, taskId) {


    $scope.ok = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $http.get('/api/Task/DefaultAction/' + taskId)
.success(function (response) {

    $scope.taskForm = response,
    $scope.formInfo = { Id: $scope.taskForm.Id, FolderId: $scope.taskForm.FolderId, Title: $scope.taskForm.Title, Description: $scope.taskForm.Description, DueTime: $scope.taskForm.DueTime, IsCompleted: $scope.taskForm.IsCompleted };

});

    $scope.editTask = function (taskId) {

        Id = $scope.formInfo.Id,
        FolderId = $scope.formInfo.FolderId,
        Title = $scope.formInfo.Title,
        Description = $scope.formInfo.Description,
        DueTime = $scope.formInfo.DueTime,
        IsCompleted = $scope.formInfo.IsCompleted

        $scope.putTask();
    };

    $scope.putTask = function () {
        var value = {
            Id: $scope.formInfo.Id,
            FolderId: $scope.formInfo.FolderId,
            Title: $scope.formInfo.Title,
            Description: $scope.formInfo.Description,
            DueTime: $scope.formInfo.DueTime,
            IsCompleted: $scope.formInfo.IsCompleted
        };

        $.post("api/Task/PutTask",
          value,
           function (value) {
               // Refresh list   
               $http.get('/api/Task/DefaultAction/' + taskId)
                .success(function (response) {
                    $scope.taskForm = response,
                    $scope.formInfo = { Id: $scope.taskForm.Id, FolderId: $scope.taskForm.FolderId, Title: $scope.taskForm.Title, Description: $scope.taskForm.Description, DueTime: $scope.taskForm.DueTime, IsCompleted: $scope.taskForm.IsCompleted };

                });
           },
           "json"
          );
    }

});

angular.module('AngularJS').controller('TasksCtrl', function ($scope, $http, $uibModal, myService) {
    $scope.folder = [{}];
    $scope.taskList = myService.taskLis;
    $scope.tasks = [{}];
    $scope.userId;
    $scope.taskWithParentFolderId = [];
    $scope.post = [{}];
    $scope.formInfo = [{}];

    
    $scope.models = {
        selected: null,
        lists: $scope.taskWithParentFolderId
    };


    // Model to JSON for demo purpose
    $scope.$watch('models', function (model) {
        $scope.modelAsJson = angular.toJson(model, true);
    }, true);

    $scope.onDrop = function (list, item, index) {

        var value = {
            ListId: list.Id,
            TaskId: item.Id,
            Index: index
        };
        $.post("api/Task/RerangeTask",
              value,
               function (value) {
                   // Refresh list   
                   $http.get('/api/Task/GetByParentId/' + list.Id)
                    .success(function (response) {
                        $scope.taskWithParentFolderId[list.Id] = response;
                    });

                   $http.get('/api/Task/GetByParentId/' + item.FolderId)
                      .success(function (response) {
                          $scope.taskWithParentFolderId[item.FolderId] = response;
                      });

               },
               "json"
              );
        return true;
    }



    $scope.open = function (size, taskId) {
        $scope.taskId = taskId
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'Task.html',
            controller: 'ModalTaskCtrl',
            size: size,
            resolve: {
                taskId: function () {
                    return $scope.taskId;
                }

            }
        });
    };
 
    $scope.addOneTask = function (parentId, inputValue) {
      
            //
            var value = {
                FolderId: parentId,
                Title: inputValue
            };

            $.post("api/Task/DefaultAction",
               value,
                function (value) {
                    // Refresh list   
                    $http.get('/api/Task/GetByParentId/' + parentId)
                     .success(function (response) {
                         $scope.taskWithParentFolderId[parentId] = response;
                     });
                },
                "json"
               );
    }

    $scope.getTaskFromParentFolder = function (parentId) {
        $http.get('/api/Task/GetByParentId/' + parentId)
     .success(function (response) {
         $scope.taskWithParentFolderId[parentId]= response;

     });
    }

    // Get folder's list 
    $scope.getTask = function (id) {
        $scope.userId=id;
        $http.get('/api/Folder/DefaultAction/' + id)
       .success(function (response) {
           $scope.folder = response;
           
       });
    }

    $scope.addAlert = function (id) {
        //
        var temp = document.getElementById('newListTaskList').value;
        var value = {
            Title: temp,
            UserId: $scope.userId            
        };

        $.post("api/Folder/DefaultAction",
           value,
            function (value) {
                // Refresh list   
                $http.get('/api/Folder/DefaultAction/' + id)
                 .success(function (response) {
                     $scope.folder = response;
                 });
            },
            "json"
           );
            
    };

    $scope.closeAlert = function (index, folderId) {
        $http.delete('api/Folder/DefaultAction/' + folderId).success(function () {
            $scope.folder.splice(index, 1);
        });
    }

    $scope.showListTask = function (listId) {
        myService.id = listId;
        $scope.canMakeTask = true;
        $http.get('/api/Folder/GetByParentId/' + listId).success(function (response) {
            $scope.taskList = response;
            myService.taskList = response;
            $scope.models.items = response;

      })
    }                              

    $scope.addTaskList = function (taskId) {
        var temp = document.getElementById('newTaskList').value;
        var value = {
            Title: temp,
            ParentFolderId: taskId,
        };

        $.post("api/Folder",
           value,
            function (value) {
                // Refresh list   
                $http.get('/api/Folder/GetByParentId/' + taskId)
                 .success(function (response) {
                     $scope.taskList = response;
                     myService.taskList = response;
                 });
            },
            "json"
           );
    }

    $scope.getValue = function () {
        return myService.taskList;        
    }

    $scope.getId = function () {
        return myService.id;
    }
})