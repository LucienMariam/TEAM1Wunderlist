angular.module('AngularJS').service('myService', function () {

    this.id;
    this.taskList;
    
});

angular.module('AngularJS').controller('TasksCtrl', function ($scope, $http, myService) {
    $scope.folder = [{}];
    $scope.taskList = myService.taskLis;
    $scope.tasks = [{}];
    $scope.userId;
    
    // Get folder's list 
    $scope.getTask = function (id) {
        $scope.userId=id;
        $http.get('/api/Folder/' + id)
       .success(function (response) {
           $scope.folder = response;
           
       });}

    $scope.addAlert = function (id) {
        //
        var temp = document.getElementById('newListTaskList').value;
        var value = {
            Title: temp,
            UserId: $scope.userId            
        };

        $.post("api/Folder",
           value,
            function (value) {
                // Refresh list   
                $http.get('/api/Folder/' + id)
                 .success(function (response) {
                     $scope.folder = response;
                 });
            },
            "json"
           );
            
    };

    $scope.closeAlert = function (index, folderId) {
        $http.delete('api/Folder/' + folderId).success(function () {
            $scope.folder.splice(index, 1);
        });
    }

    $scope.showListTask = function (Id) {
        myService.id = Id;
        $scope.canMakeTask = true;
        $http.get('/api/Task/' + Id).success(function (response) {
            $scope.taskList = response;
            myService.taskList = response;
      })
    }

    $scope.addTask = function (id) {
        var temp = document.getElementById('newTaskList').value;
        var value = {
            Title: temp,
            FolderId: id,
            IsCompleted: false
        };

        $.post("api/Task",
           value,
            function (value) {
                // Refresh list   
                $http.get('/api/Task/' + id)
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