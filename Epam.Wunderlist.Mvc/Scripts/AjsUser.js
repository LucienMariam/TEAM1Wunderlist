angular.module('AngularJS', ['ngAnimate', 'ui.bootstrap']);
angular.module('AngularJS').controller('ModalDemoCtrl', function ($scope, $uibModal) {
   

    $scope.animationsEnabled = true;
    $scope.formInfo = {};
    $scope.open = function (size, email) {
       
        $scope.email = email
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                email: function () {
                    return $scope.email;
                }

            }
        });
    };

});

// Please note that $uibModalInstance represents a modal window (instance) dependency.
// It is not the same as the $uibModal service used above.

angular.module('AngularJS').controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, $http, email ) {


    $scope.ok = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    {
    // Get customer list   
        $http.get('/api/Default/' + email)
    .success(function (response) {
        $scope.Customer = response,
        $scope.formInfo = { Login: $scope.Customer.Login, Email: $scope.Customer.Email, Id: $scope.Customer.Id };
        
    });
    // Initial   
    $scope.edit = true;
    $scope.error = false;
    $scope.incomplete = false;
    // Edit   
    $scope.editCustomer = function (id) {
       
        if (id == 'new') {
            $scope.edit = true;
            $scope.incomplete = true;
            $scope.ID = 0;
            $scope.Login = '';
            $scope.Email = '';
        } 
            $scope.edit = false;
            $scope.ID = $scope.Customer.Id;
            $scope.Photo = $scope.Customer.Photo;
            $scope.Login = $scope.Customer.Login.trim();
            $scope.Email = $scope.Customer.Email.trim();
            $("#idEmail").val($scope.Email.trim());
            $scope.incomplete = false;
            
            $scope.PostCustomer();
    };
    // Update or add new one    
    $scope.PostCustomer = function () {
        var value = {
            login: $scope.formInfo.Login,
            email: $scope.formInfo.Email,
            password: $scope.formInfo.Password
            //id: $scope.formInfo.Id

        };
       
        $.post("api/Default",
          value,
           function (value) {
               // Refresh list   
               $http.get("/api/Default")
               .success(function (response) {
                   $scope.Customer = response
               });
               alert("Saved successfully.");
           },
           "json"
          );
    }
    // Delete one customer based on id.   
    //$scope.delCustomer = function (id) {
    //    if (confirm("Are you sure you want to delete this customer?")) {
    //        // todo code for deletion   
    //        $http.delete("api/customerapi/" + id).success(function () {
    //            alert("Deleted successfully.");
    //            // Refresh list   
    //            $http.get("/api/customerapi")
    //            .success(function (response) {
    //                $scope.Customer = response
    //            });
    //        }).error(function () {
    //            alert("Error.");
    //        });
    //    }
    //};
    }
});


