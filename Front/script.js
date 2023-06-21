async function GetSocio(id) {
  let url = "https://localhost:7175/api/Socio/GetSocioById/" + id;


  try {
    const response = await fetch(url);

    if (!response.ok) {
      throw new Error("Error en la solicitud");
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.log(error);
  }
}

async function ShowSocio(id) {
  try {
    let socioJson = await GetSocio(id);
    console.log(socioJson)
    const tabla = document.getElementById("tabla");
    const encabezado = document.createElement('tr');
    for (const key in socioJson) {

      const th = document.createElement("th");
      console.log(key)
      th.textContent = key;
      encabezado.appendChild(th);

    }
    tabla.appendChild(encabezado);
    //contenido
    const content = document.createElement('tr');
    for (const key in socioJson) {

      const td = document.createElement("td");
      console.log(socioJson[key])
      td.textContent = socioJson[key] !== null ? socioJson[key] : 'null';;
      content.appendChild(td);

    }
    tabla.appendChild(content);


  } catch (error) {
    console.log(error)
  }
}


const btnConsultar = document.getElementById("btn-consultar");
btnConsultar.addEventListener("click", () => {
  const id = document.getElementById("inputID").value;
  console.log(id)
  ShowSocio(id);
})
