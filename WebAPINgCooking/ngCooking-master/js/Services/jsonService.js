﻿(function () {
    var jsonService = function($http)
    {
        var getRecipes = function () {
            return $http.get("json/recettes.json").then(function (response) { return response.data; });
        };
        var getUsers = function () {
            return $http.get("json/communaute.json").then(function (response) { return response.data; });
        };
        var getIngredients = function () {
            return $http.get("json/ingredients.json").then(function (response) { return response.data; });
        };
        var getCategories = function () {
            return $http.get("json/categories.json").then(function (response) { return response.data; });
        };
        var getRecipesApi = function () {
            return $http.get("../api/Recipes").then(function (response) { return response.data; });
        };
        var getUsersApi = function () {
            return $http.get("../api/Users").then(function (response) { return response.data; });
        };
        var getIngredientsApi = function () {
            return $http.get("../api/Ingredients").then(function (response) { return response.data; });
        };
        var getCategoriesApi = function () {
            return $http.get("../api/Categories").then(function (response) { return response.data; });
        };
        var setRecettes = function (data) {

            //$http({
            //    method: 'POST',
            //    url: 'json/recettes.json',
            //    headers: {
            //        'Content-Type': "json/recettes.json",
            //        'Accept': "json/recettes.json"
            //    },
            //    data: data})
            return $http.put('json/recettes.json', data, {
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': 'json',
                    'Accept': 'json'
                }
            })
            .then(function (response) { console.log("Data stored"); return "Data stored"; });
        };
        return {
            getRecipes: getRecipes,
            getUsers: getUsers,
            getIngredients: getIngredients,
            getCategories: getCategories,
            getRecipesApi: getRecipesApi,
            getUserApi: getUsersApi,
            getIngredientsApi: getIngredientsApi,
            getCategoriesApi: getCategoriesApi,
            setRecettes: setRecettes
        }
    }
    var module = angular.module('ngCooking');
    module.factory('json', jsonService);
}());