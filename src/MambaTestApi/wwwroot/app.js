!function(){"use strict";angular.module("MambaTestApp",["JawBoneServices"])}(),function(){"use strict";function a(a,b){a.activityJawData="Empty",a.heartRateJawData="Empty",a.fetchActivity=function(){a.activityJawData=b.activity.get()},a.fetchHeartRate=function(){a.heartRateJawData=b.heartRate.get()}}angular.module("MambaTestApp").controller("jawBoneController",a),a.$inject=["$scope","JawBone"]}(),function(){"use strict";var a=angular.module("JawBoneServices",["ngResource"]);a.factory("JawBone",["$resource",function(a){return{activity:a("/api/jawbone/getactivity",{},{get:{method:"GET",params:{},isArray:!1}}),heartRate:a("/api/jawbone/getheartrate",{},{get:{method:"GET",params:{},isArray:!1}})}}])}();