import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ConsultoresService } from '../../Services/consultores.service'
import { Consultores } from '../../Models/consultores'
import * as FusionCharts from 'fusioncharts';

@Component({
  selector: 'app-consultors-agence-teste',
  templateUrl: './consultors-agence-teste.component.html',
  styleUrls: ['./consultors-agence-teste.component.css']
})
export class ConsultorsAgenceTesteComponent implements OnInit {
  
  dataSource: Object;
  form: FormGroup;

  constructor(private consultoresServices : ConsultoresService, private formBuilder: FormBuilder, private toastr: ToastrService,) { 

    this.form = this.formBuilder.group({
      desde:['',  [Validators.required, Validators.minLength(1), Validators.maxLength(10)]],
      hasta:['', [Validators.required, Validators.minLength(1), Validators.maxLength(10)]],
      select1:[''],
      select2:['', [Validators.required]]
    });
  }

   allConsultores = [];
   secondselect = [];
   dummyData = [];
   dummyData2 = [];
   dataSaldo = [];
   consult : boolean = false;
   ConsultoresFlag : boolean = false;
   lineChartDiv : boolean = false;
   pizzaPieChartDiv : boolean = false;
   activateChartsButton : boolean = false;
   listLabel = [];
   sinCoincidenciasFalg : boolean = false;
   spinnerFlag : boolean = false;
   _listCategories2 = [];
   firtsTimeLineChart : boolean = true;
   firtsTimePizzaChart: boolean = true;
   isClicked : boolean = true;
   

  async ngOnInit(): Promise<void> {

    //Set de input in Sept 2007
    this.allConsultores = await this.consultoresServices.getAllConsultores();

    console.log(this.allConsultores);

    console.log(this.dummyData);

  }

/* Metodo que se encarga de pasar los usuarios seleccionados del SelectBox 1 al SelectBox 2
  *
  */
  pullSelect_1to_2(){
    if(this.form.value["select1"] == null ){
    this.toastr.warning('Seleccione un Consultor!', 'Advertencia ');
    }else{
    let _arrayIn = this.form.value["select1"];

    for(let i = 0; i < _arrayIn.length; i++){ 
      this.allConsultores = this.allConsultores.filter(e => e !== _arrayIn[i]); // will return ['A', 'C']
      this.secondselect.push(_arrayIn[i]);
      this.form .controls['select1'].reset()
      console.log(this.allConsultores);
      console.log(this.secondselect);
      }

      console.log(this.allConsultores);
    }
  }


  /* Metodo que se encarga de pasar los usuarios seleccionados del SelectBox 2 al SelectBox 1
  *
  */
  pullSelect_2to_1(){
    if(this.form.value["select2"] == null ){
    this.toastr.warning('Seleccione un Consultor!', 'Advertencia ');
    }else{
    let _arrayIn = this.form.value["select2"];

    for(let i = 0; i < _arrayIn.length; i++){ 
      this.secondselect = this.secondselect.filter(e => e !== _arrayIn[i]); // will return ['A', 'C']
      this.allConsultores.push(_arrayIn[i]);
      this.form .controls['select2'].reset()
      }

      console.log(this.allConsultores);
    }
  }



/* Metodo que se encarga de realizar la llamada al servicio para Obtener las receitas 
* y demas informacion con los parametros de Fecha y Consultores indicados.
*
*/
  async metodo(){
    this.dummyData2 = [];

    this.activateChartsButton = false;
    this.sinCoincidenciasFalg = false;
    this.lineChartDiv = false;
    this.pizzaPieChartDiv = false;

    console.log(this.dummyData2);

    if(this.secondselect.length == 0 || this.form.value["desde"] == "" || this.form.value["hasta"] ==  ""){
    this.toastr.warning('Seleccione un Consultor y las fechas del Periodo', 'Advertencia ');
    }
    else{
      this.consult = true;
      let _arrayDate = [];

      _arrayDate = this.form.value["hasta"].split("-");
    
      let _lastDay : number = new Date(parseInt(_arrayDate[0]), parseInt(_arrayDate[1]),0).getDate();

      let Date1 : string = this.form.value["desde"] + "-01";
      let Date2 : string = this.form.value["hasta"] + "-"+ _lastDay.toString();
      
      var d1 = Date.parse(Date1);
      var d2 = Date.parse(Date2);
      console.log(d1);
      console.log(d2);
  
      if (d2 < d1) {
        this.toastr.warning('Seleccione un Consultor y las fechas del Periodo', 'Advertencia!');
        return;
      }

    this.spinnerFlag = true;
    this.consult = true;

     let _consultores : any = [];

    for (let index = 0; index < this.secondselect.length; index++) {

      let _objeto : Consultores = {
        //Colocar desde y hasta
        id : 0,
        userName :  this.secondselect[index]
         ,
         date1: Date1,
         date2: Date2
      }
      _consultores.push(_objeto);
    }

    this.dummyData2 = await this.consultoresServices.getReceitasConsultores(_consultores, this.form.value["desde"], this.form.value["select2"]);
    console.log(this.dummyData2);

    if(this.dummyData2.length == 0){

      this.spinnerFlag = false;
      this.sinCoincidenciasFalg = true;
      this.activateChartsButton = false;

    } else{
      this.activateChartsButton = true;
      this.spinnerFlag = false;
      for (var i = 0; i < this.dummyData2.length; i++){
        
        console.log(this.dummyData2[i].listaReceitas);
  
        let _receita : number = 0.0;
        let _custoFixo : number = 0.0;
        let _comisao : number = 0.0;
        let _lucro : number = 0.0;
        
  
        for (var j = 0; j < this.dummyData2[i].listaReceitas.length; j++){

          this.dummyData2[i].listaReceitas[j].lucro = parseFloat(this.dummyData2[i].listaReceitas[j].lucro).toFixed(2);

          _receita    = _receita + parseFloat(this.dummyData2[i].listaReceitas[j].receita);
          _custoFixo  = _custoFixo + parseFloat(this.dummyData2[i].listaReceitas[j].custoFixo)
          _comisao  = _comisao + parseFloat(this.dummyData2[i].listaReceitas[j].comisao)
          _lucro  = _lucro + parseFloat(this.dummyData2[i].listaReceitas[j].lucro)
  
          
        }
        this.dummyData2[i].saldo = [{"saldoreceita":_receita.toFixed(2), "saldocusto":_custoFixo.toFixed(2), "saldocomisao":_comisao.toFixed(2), "saldolucro":_lucro.toFixed(2)}]
    }
    // debugger
    console.log(this.dummyData2);
    
    this.firtsTimeLineChart = true;
    this.firtsTimePizzaChart = true;
    this.activateChartsButton = true;

    }

  }

}


/* Metodo que se encarga de realizar la llamada al servicio para Obtener las receitas 
* y demas informacion con los parametros de Fecha y Consultores indicados.
*
*/
async metodoLineChart(){

  //debugger
  this.consult = false;
  this.lineChartDiv = true;
  this.pizzaPieChartDiv = false;

  let _listData2 = [];
  let _listDataSet = [];
  let categories = [];

  var _contadorMaxMes = 0;
  var _posicionConsulorList = 0;

  let arrayMesesMaximos = [];
  let arrayCustoMedioFijo = [];


   //Verifico el que tenga la mayor cantidad de meses, para posteriormente configurar la Data en Categories.
   for (var i = 0; i < this.dummyData2.length; i++){
      //debugger
      if(this.dummyData2[i].listaReceitas.length > _contadorMaxMes){
        _posicionConsulorList = i
        _contadorMaxMes = this.dummyData2[i].listaReceitas.length;
    }    
  }
  console.log(this.dummyData2[_posicionConsulorList]);
  
  // Recorro el arreglo que mas meses tiene y lo agregor a la lista de Categories con la data correspondiente.
   for (var i = 0; i < this.dummyData2[_posicionConsulorList].listaReceitas.length; i++){
    var objectLabel = {
        "label" :  this.dummyData2[_posicionConsulorList].listaReceitas[i].periodo
    }
    this._listCategories2.push(objectLabel);
    arrayMesesMaximos.push( this.dummyData2[_posicionConsulorList].listaReceitas[i].periodo);

  }

  //Configuro las etiquetas con el array _listCategories2 que contienen todos los meses consultados
   categories = [
    {
      "category": this._listCategories2
    }
  ]

// Metodo encargado de llenar los meses faltantes en cada Consultor
  for (var i = 0; i < this.dummyData2.length; i++){
  arrayMesesMaximos.forEach( mounth => {
    if (!this.dummyData2[i].listaReceitas.find(m => m.periodo === mounth)) {
      this.dummyData2[i].listaReceitas.push({"periodo": mounth, "receita":"0", "custoFixo":"0", "comisao":"0", "lucro":"0"});
    }
   });

}

// Metodo encragado de hacer un ordenamiento segun el arrayMesesMaximos
for (var i = 0; i < this.dummyData2.length; i++){
  this.dummyData2[i].listaReceitas.sort(function (a, b) {
    return arrayMesesMaximos.indexOf(a.periodo) - arrayMesesMaximos.indexOf(b.periodo);
  });
  console.log(this.dummyData2[i].listaReceitas);

}

console.log(this.dummyData2);


let _listCustoFixo = []; 

// Seteo los datos del Grafico de Barras con las recetas por cada mes arrojado en la Consulta
  for (var i = 0; i < this.dummyData2.length; i++){
    //debugger
    var objectDataSet = {

        "seriesName": this.dummyData2[i].name,
        "showValues": "1",
        "data" : []
    }

    for (var j = 0; j < this.dummyData2[i].listaReceitas.length; j++){
      //debugger
      
      var _data = {
        "value" : this.dummyData2[i].listaReceitas[j].receita
      }

      //If que va sumando el Costo Fijo de cada Mes y cada consultor.
      if(_listCustoFixo.length < arrayMesesMaximos.length ){

        _listCustoFixo.push(this.dummyData2[i].listaReceitas[j].custoFixo);

      }else{
      console.log(_listCustoFixo[j]);
      console.log(this.dummyData2[i].listaReceitas[j].custoFixo);
      _listCustoFixo.splice(j , 1 , parseFloat(_listCustoFixo[j]) + parseFloat(this.dummyData2[i].listaReceitas[j].custoFixo))


      }
      _listData2.push(_data);

    }

    objectDataSet.data = _listData2;
    _listDataSet.push(objectDataSet);
    _listData2 = [];
  }


  var lineChartDataSet = {

    "seriesName": "Costo Fijo Promedio",
    "renderAs": "line",
    "data" : []
}

//Recorro la suma de los Costos Fijos por mes y los divido entre la cantidad de Consultores Involucrados en la Consulta
  for (var i = 0; i < _listCustoFixo.length; i++){

    var _dataCusto = {
      "value" : _listCustoFixo[i] / this.dummyData2.length
    }

    arrayCustoMedioFijo.push(_dataCusto)

  }

  // debugger
  lineChartDataSet.data = arrayCustoMedioFijo;

  _listDataSet.push(lineChartDataSet)
// debugger
    var dataset = _listDataSet;

    this.dataSource = {
      "chart": {
      "caption": "Performance Comercial",
      "subCaption": "Sales analysis of last year",
      "xAxisname": "", //"Month",
      "yAxisName": "", // "Amount (In USD)",
      "sYAxisMaxValue" : "32000",
      "pYAxisMaxValue" : "32000",
      "numberPrefix": "\R$",
      "divlineColor": "#999999",
      "divLineIsDashed": "1",
      "divLineDashLen": "1",
      "divLineGapLen": "1",
      "toolTipColor": "#ffffff",
      "toolTipBorderThickness": "0",
      "toolTipBgColor": "#000000",
      "toolTipBgAlpha": "80",
      "toolTipBorderRadius": "2",
      "toolTipPadding": "5",
      "theme": "fusion"
      },
      "categories": categories,
      "dataset": dataset
      
    };

    this._listCategories2 = []
}



/* Metodo que se encarga de realizar la llamada al servicio para Obtener las receitas 
* y demas informacion con los parametros de Fecha y Consultores indicados.
*
*/
async metodoPizzaPieChart(){

  this.consult = false;
  this.lineChartDiv = false;
  this,this.pizzaPieChartDiv = true;



console.log(this.dummyData2);

let _listPie = [];

for (var i = 0; i < this.dummyData2.length; i++){
  // debugger
        var objectLabel = {
            "label" :  this.dummyData2[i].name,
            "value" :  this.dummyData2[i].saldo[0].saldoreceita
        }
        _listPie.push(objectLabel);
}

  this.dataSource = {
    "chart": {
        "caption": "Participacao na Receita Liquida",
        "subCaption": "",
        "numberPrefix": "R$",
        "showPercentInTooltip": "0",
        "decimals": "1",
        "useDataPlotColorForLabels": "1",
        //Theme
        "theme": "fusion"
    },
    "data": _listPie
};


}


mantenercolorButtonConsultor(){
  this.ConsultoresFlag = true;
  var element = document.getElementById("ConsultorButton");
  element.style.background = "#0d6efd";
  element.style.color = "#fff";

  var element = document.getElementById("ClienteButton");
  element.removeAttribute("style");
  

}

mantenercolorButtonCliente(){
  this.ConsultoresFlag = false;
  var element = document.getElementById("ClienteButton");
  element.style.background = "#0d6efd";
  element.style.color = "#fff";

  var element = document.getElementById("ConsultorButton");
  element.removeAttribute("style");
}



}
