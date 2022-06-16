import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideBarComponent } from './Components/side-bar/side-bar.component';
import { HomeComponentComponent } from './Components/home-component/home-component.component';
import { CreditCardComponent } from './Components/credit-card/credit-card.component';
import { ListaTarjetasCreditoComponent } from './Components/lista-tarjetas-credito/lista-tarjetas-credito.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule } from '@angular/common/http';
import { ConsultorsAgenceTesteComponent } from './Components/consultors-agence-teste/consultors-agence-teste.component';
import { ReaisPipe } from './Pipes/reais.pipe';
import { FusionChartsModule } from "angular-fusioncharts";

//Import FusionCharts library and chart modules
import * as FusionCharts from "fusioncharts";
import * as charts from "fusioncharts/fusioncharts.charts";
import * as FusionTheme from "fusioncharts/themes/fusioncharts.theme.fusion";
import { ReaisNegativePipe } from './Pipes/reais-negative.pipe';

FusionChartsModule.fcRoot(FusionCharts, charts, FusionTheme);

@NgModule({
  declarations: [
    AppComponent,
    SideBarComponent,
    HomeComponentComponent,
    CreditCardComponent,
    ListaTarjetasCreditoComponent,
    ConsultorsAgenceTesteComponent,
    ReaisPipe,
    ReaisNegativePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    FusionChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
