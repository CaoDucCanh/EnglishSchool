(function (app) {
    'use strict';

    app.controller('applicationUserAddController', applicationUserAddController);

    applicationUserAddController.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function applicationUserAddController($scope, apiService, notificationService, $location, commonService) {
        $scope.account = {
         CreatedDate:new Date()
        }
      
        function loadTypeuser() {
            apiService.get('api/Typeuser/getalltype', null, function (result) {
                $scope.Typeuser = result.data;
            }, function (){
                    console.log('cannot get typeuser');
                
            });
        }
        $scope.addAccount = addAccount;

        function addAccount() {
            apiService.post('/api/applicationUser/add', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.Name + ' đã được thêm mới.');

            $location.url('application_users');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

      
        loadTypeuser();
    }
})(angular.module('englishschool.application_users'));