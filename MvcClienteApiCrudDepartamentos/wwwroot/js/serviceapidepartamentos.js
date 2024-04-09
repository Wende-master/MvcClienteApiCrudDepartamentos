var urlApi = "https://apicorecruddepartamentoswende.azurewebsites.net/";

function deleteDepartamentoAsync(id, callBack) {
    var request = "api/departamentos/" + id;
    $.ajax({
        url: urlApi + request,
        type: "DELETE",
        success: function () {
            callBack();
        }
    });
}

function getJsonDepartamentosAsync(callBack) {
    var request = "api/departamentos"
    $.ajax({
        url: urlApi + request,
        type: "GET",
        success: function (data) {
            callBack(data);

        }
    });
}

function convertirDeptToJson(/*id,*/ nombre, localidad) {
    var dept = new Object();
    //dept.idDepartamento = id
    dept.nombre = nombre;
    dept.localidad = localidad;
    var dataJson = JSON.stringify(dept);
    return dataJson;
}

function insertDepartamentoAsync(/*id*/ nombre, localidad, callBack) {
    var dataJson = convertirDeptToJson(/*id, */nombre, localidad);
    var request = "api/departamentos";
    $.ajax({
        url: urlApi + request,
        type: "POST",
        data: dataJson,
        contentType: "application/json",
        success: function () {
            callBack();
        }
    });
}

function updateDepartamentoAsync(id, nombre, localidad, callBack) {
    var dept = new Object();
    dept.idDepartamento = id
    dept.nombre = nombre;
    dept.localidad = localidad;
    var dataJson = JSON.stringify(dept);
    var request = "api/departamentos";
    $.ajax({
        url: urlApi + request,
        type: "PUT",
        data: dataJson,
        contentType: "application/json",
        success: function () {
            callBack();
        }
    });
}