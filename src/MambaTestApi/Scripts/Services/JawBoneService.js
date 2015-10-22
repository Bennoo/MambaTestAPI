(function () {
    'use strict';

    var JawBoneServices = angular.module('JawBoneServices', ['ngResource']);

    JawBoneServices.factory('JawBoneService', ['$resource',
      function ($resource) {
          return {
              activity: $resource('/api/jawbone/getactivity', {}, {
                  get: { method: 'GET', params: {}, isArray: false }
              }),
              heartRate: $resource('/api/jawbone/getheartrate', {}, {
                  get: { method: 'GET', params: {}, isArray: false }
              })
          };
      }]);


})();