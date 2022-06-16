import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Tarjeta } from 'src/app/Models/tarjeta';
import { TarjetaCreditoService } from 'src/app/Services/tarjeta-credito.service';

@Component({
  selector: 'app-lista-tarjetas-credito',
  templateUrl: './lista-tarjetas-credito.component.html',
  styleUrls: ['./lista-tarjetas-credito.component.css']
})
export class ListaTarjetasCreditoComponent implements OnInit {

  listTarjetas : Tarjeta[] ;

  constructor(private toastr: ToastrService, public tarjetaService : TarjetaCreditoService) { }

  ngOnInit(): void {
    this.getTarjetas();
  }

  getTarjetas(){
    this.tarjetaService.getAllTarjetas();
  }


  eliminarTarjeta(_tarjetaDelete : Tarjeta){
    console.log(_tarjetaDelete.id);

    this.tarjetaService.eliminarTarjeta(_tarjetaDelete).subscribe( data => {
      
      this.toastr.warning('La tarjeta fue eliminada correctamente!', 'Tarjeta Eliminada!');
      this.getTarjetas();
    }, 
    error => {
      console.log(error);
      this.toastr.error('Error al eliminar la tarjeta', 'Error');
    });

  }

  modificarTarjeta(tarjeta:any){

    //Envio la informacion de la tarjeta especifica al Componente CreditCard
    this.tarjetaService.envioInfEntreComponentes(tarjeta);
    
  }

}
