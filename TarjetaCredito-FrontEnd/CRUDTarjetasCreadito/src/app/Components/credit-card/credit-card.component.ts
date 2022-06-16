import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Tarjeta } from 'src/app/Models/tarjeta';
import { TarjetaCreditoService } from '../../Services/tarjeta-credito.service'

@Component({
  selector: 'app-credit-card',
  templateUrl: './credit-card.component.html',
  styleUrls: ['./credit-card.component.css']
})
export class CreditCardComponent implements OnInit,OnDestroy {

  listTarjetas : Tarjeta;
  idModifTarjeta : number = undefined;
  accion : string = "Agregar";

  form: FormGroup;

  subscription : Subscription;

  constructor(private formBuilder: FormBuilder, private toastr: ToastrService, private tarjetaService : TarjetaCreditoService) {
    this.form = this.formBuilder.group({
      Nombre:['',  [Validators.required, Validators.minLength(10), Validators.maxLength(20)]],
      numeroTarjeta:['', [Validators.required, Validators.minLength(16), Validators.maxLength(16)]],
      fechaExp:['' , [Validators.required, Validators.minLength(1)]],
      cvv:['', [Validators.required, Validators.min(1), Validators.max(999)]]
    })
   }

  ngOnInit(): void {
    this.subscription = this.tarjetaService.reciboTarjeta().subscribe( data =>{
      console.log(data);
      this.form.controls["Nombre"].setValue(data.nombre);
      this.form.controls["numeroTarjeta"].setValue(data.numeroTarjeta)
      this.form.controls["fechaExp"].setValue(data.fechaExp)
      this.form.controls["cvv"].setValue(data.cvv);

      this.idModifTarjeta = data.id;
      
    });
  }
  

  ngOnDestroy() {
        this.subscription.unsubscribe();
  }

  SendData(){

    let tarjeta : any = {
      Nombre: this.form.value["Nombre"],
      numeroTarjeta: this.form.value["numeroTarjeta"],
      fechaExp: this.form.value["fechaExp"],
      cvv: this.form.value["cvv"] 
    }

    if(this.idModifTarjeta != undefined){

      tarjeta.id =  this.idModifTarjeta;

      this.tarjetaService.modificarTarjeta(this.idModifTarjeta, tarjeta).subscribe( data => {

        this.toastr.success('Se Modifico la tarjeta correctamente! ', 'Modificado Exitoso!');
        this.tarjetaService.getAllTarjetas();
        this.form.reset();
  
      }, error => {
        console.log(error);
        this.toastr.error('Error al Agregar la tarjeta!', 'Error!');
      });


    } else{

    console.log(tarjeta);

    this.tarjetaService.GuardarTarjeta(tarjeta).subscribe( data => {

      this.toastr.success('Se guardo la tarjeta correctamente! ', 'Guardado Exitoso!');
      this.tarjetaService.getAllTarjetas();
      this.form.reset();

    }, error => {
      console.log(error);
      this.toastr.error('Error al Agregar la tarjeta!', 'Error!');
    });
          }

  }


  eliminarTarjeta(_tarjetaDelete : Tarjeta){
    console.log(_tarjetaDelete.id);

    this.tarjetaService.eliminarTarjeta(_tarjetaDelete).subscribe( data => {
      
      this.toastr.warning('La tarjeta fue eliminada correctamente!', 'Tarjeta Eliminada!');
      this.tarjetaService.getAllTarjetas();
    }, 
    error => {
      console.log(error);
      this.toastr.error('Error al eliminar la tarjeta', 'Error');
    });

  }

  // modificarTarjeta(tarjeta:any){

  //   this.form.controls["Nombre"].setValue(tarjeta.nombre);
  //   this.form.controls["numeroTarjeta"].setValue(tarjeta.numeroTarjeta)
  //   this.form.controls["fechaExp"].setValue(tarjeta.fechaExp)
  //   this.form.controls["cvv"].setValue(tarjeta.cvv);

  //   this.idModifTarjeta = tarjeta.id;
  //   this.accion = "Modificar"; 
    
  // }

}
