(function () {
    'use strict';

    var JawBoneAPIServices = angular.module('JawBoneAPIServices', ['ngResource']);

    JawBoneAPIServices.factory('JawBoneAPI', ['$resource',
      function ($resource) {
          return $resource('/api/movies/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);


})();