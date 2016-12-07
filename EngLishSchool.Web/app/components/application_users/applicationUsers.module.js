/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('englishschool.application_users', ['englishschool.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('application_users', {
            url: "/application_users",
            templateUrl: "/app/components/application_users/applicationUserListView.html",
     
            controller: "applicationUserListController"
        })
            .state('add_application_user', {
                url: "/add_application_user",
      
                templateUrl: "/app/components/application_users/applicationUserAddView.html",
                controller: "applicationUserAddController"
       
            });
    }
})();