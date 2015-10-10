(function () {
    'use strict';

    angular
        .module('MambaTestApp')
        .controller('JawBoneController', JawBoneController);

    JawBoneController.$inject = ['$scope', 'JawBoneAPI']; 

    function JawBoneController($scope, JawBoneAPI) {
        $scope.JawBoneData = JawBoneAPI.query();
    }
})();
