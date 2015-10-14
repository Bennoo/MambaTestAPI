(function () {
    'use strict';

    angular
        .module('MambaTestApp')
        .controller('jawBoneController', jawBoneController);

    jawBoneController.$inject = ['$scope', 'JawBone'];

    function jawBoneController($scope, JawBone) {
        $scope.activityJawData = 'Empty';
        $scope.heartRateJawData = 'Empty';

        $scope.fetchActivity = function () {            
            $scope.activityJawData = JawBone.activity.get();
        };
        
        $scope.fetchHeartRate = function () {
            $scope.heartRateJawData = JawBone.heartRate.get();
        }        
    }
})();