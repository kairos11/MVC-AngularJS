var app = angular.module('WebApp3', []);

app.controller('SyllabusController', function ($scope, $http, $window) {
    $scope.btntext = "Save";

    //Save Data using SyllabusController
    $scope.savedata = function () {
        $scope.btntext = "Please wait...";

        $http({
            method: 'POST',
            url: '/Syllabus/AddData',
            data: $scope.register
        }).then(function (d) {
            $scope.btntext = "Save";
            $scope.register = null;
            $window.alert("Successfully save");
            $window.location.reload();
        }).catch(function (d) {
            $window.alert('Failed to save');
        });

    }


    //Update Record

    $scope.Update_Data = function () {

        $scope.btntext = "Please Wait..";

        $http({
            method: 'POST',
            url: '/Syllabus/UpdateRecord',
            contentType: "application/json",
            data: $scope.record
        }).then(function () {
            $scope.btntext = "Update";
            $scope.record = null;
            //alert(d);
            $window.location.href= "/Syllabus/Index";
            $route.reload();
        });

    };

    //Delete record
    $scope.Delete = function (id) {
        var response = $http({
            method: 'POST',
            //url: '/WebAppService.asmx/DeletebyId',
            url: '/Syllabus/DeleteSyllabus',
            contentType: "application/json", //"text/plain",
            params: {
                id: JSON.stringify(id)
            }
        }).then(function () {
            $window.alert("Successfully deleted.");
            $window.location.reload();
        });
        return response;
    }

    //Get List of Course in service
    $http.get("/WebAppService.asmx/GetCourse")
        .then(function (response) {
            $scope.courses = response.data;
        })

    //Get List of Subjects in service
    $http.get("/WebAppService.asmx/GetSubject")
    .then(function (response) {
        $scope.subjects = response.data;
    })

    //Get All Detals
    $http.get("/WebAppService.asmx/GetSyllabus")
    .then(function (response) {
        $scope.courseSyllabus = response.data;
    })

    //Get All Detals
    $scope.loadrecord = function (id) {
        $http.get("/WebAppService.asmx/GetSyllabusById?id=" + id).then(function (d) {
            $scope.record = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };

    //var post = $http({
    //    method: "POST",
    //    url: "/WebAppService.asmx/GetSyllabus",
    //    dataType: 'json',
    //    headers: { "Content-Type": "application/json" }
    //});
    //post.success(function (data, status) {
    //    //The received response is saved in Customers array.
    //    $scope.courseSyllabus = data;
    //});

    //Code not yet working

    $scope.savedata1 = function () {
        
        var post = $http({
            method: "POST",
            url: "/WebAppService.asmx/AddData",
            dataType: 'json',
            data: "{courseId: '" + $scope.courseId + "', subjectId: '" + $scope.subjectId + "' }",
            headers: { "Content-Type": "application/json" }
        }).then(function (data, status) {
            $scope.Syllabus.push(data);
        }).catch(function (data, status) {
            $window.alert("Failed to save " + status);
        });
    }
});
