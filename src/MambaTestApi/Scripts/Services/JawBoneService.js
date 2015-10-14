(function () {
    'use strict';

    var JawBoneServices = angular.module('JawBoneServices', ['ngResource']);

    JawBoneServices.factory('JawBone', ['$resource',
      function ($resource) {
          return $resource('/api/jawbone/getactivity', {}, {
              query: { method: 'GET', params: {}, isArray: false }
          });
      }]);


})();