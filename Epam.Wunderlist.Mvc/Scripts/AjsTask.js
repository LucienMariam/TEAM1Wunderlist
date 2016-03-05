angular.module('AngularJS').service('myService', function () {

    this.id;
    this.taskList;
});

angular.module('AngularJS').controller('TasksCtrl', function ($scope, $http, myService) {
    $scope.mainTasks = [{}];
    $scope.taskList = myService.taskLis;
    $scope.tasks = [{}];
    
    // Get customer list 
    $scope.getTask = function (email) {
        $http.get('/api/MainTask/' + email)
       .success(function (response) {
           $scope.mainTasks = response;
           
       });}

    $scope.addAlert = function (email) {
        //
        var temp = document.getElementById('newListTaskList').value;
        var value = {
            Title: temp,
        };

        $.post("api/MainTask",
           value,
            function (value) {
                // Refresh list   
                $http.get('/api/MainTask/' + email)
                 .success(function (response) {
                     //$scope.tasks = response;
                     $scope.mainTasks.push({ Title: temp });
                 });
            },
            "json"
           );
            
    };

    $scope.closeAlert = function (index, title) {
        $http.delete('api/MainTask/' + title).success(function () {
            //$scope.tasks = response;
            $scope.mainTasks.splice(index, 1);
        });
    }

    $scope.showMainListTask = function (Id) {
        myService.id = Id;
        $http.get('/api/TaskList/' + Id).success(function (response) {
            $scope.taskList = response;
            myService.taskList = response;
      })
    }

    $scope.getValue = function () {
        return myService.taskList;        
    }
    $scope.getId = function () {
        return myService.id;
    }
})