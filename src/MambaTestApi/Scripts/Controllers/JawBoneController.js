(function () {
    'use strict';

    angular
        .module('MambaTestApp')
        .controller('jawBoneController', jawBoneController);

    jawBoneController.$inject = ['$scope', 'JawBone'];

    function jawBoneController($scope, JawBone) {
        $scope.jawdata = JawBone.query();
    }
})();