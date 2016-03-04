angular.module('AngularJS').controller('TasksCtrl', function ($scope, $http) {
    $scope.tasks = [{}];
    
    // Get customer list 
    $scope.get = function (email) {
        $http.get('/api/Task/' + email)
       .success(function (response) {
           $scope.tasks = response;
       });}
    



    $scope.addAlert = function (email) {
        //
        var temp = document.getElementById('newListTaskList').value;
        var value = {
            Title: temp,
        };

        $.post("api/Task",
           value,
            function (value) {
                // Refresh list   
                $http.get('/api/Task/' + email)
                 .success(function (response) {
                     $scope.tasks.push({ Title: temp });
                 });
            },
            "json"
           );
            
    };

    $scope.closeAlert = function (index, title) {
        $http.delete('api/Task/' + title).success(function () {
            $scope.tasks.splice(index, 1);
        });}
         
})