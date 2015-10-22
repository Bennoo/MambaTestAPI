(function () {
    'use strict';

    angular
        .module('MambaTestApp')
        .controller('jawBoneController', jawBoneController);

    jawBoneController.$inject = ['$scope', 'JawBoneService'];

    function jawBoneController($scope, JawBoneService) {
        $scope.activityJawData = 'Empty';
        $scope.heartRateJawData = 'Empty';

        $scope.fetchActivity = function () {            
            $scope.activityJawData = JawBoneService.activity.get();
        };
        
        $scope.fetchHeartRate = function () {
            $scope.heartRateJawData = JawBoneService.heartRate.get();
        }        
    }
})();