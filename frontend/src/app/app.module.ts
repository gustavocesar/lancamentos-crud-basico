import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { LancamentosComponent } from './lancamentos/lancamentos.component';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { IncluirComponent } from './lancamentos/incluir/incluir.component';
import { InputMaskModule } from '@ngneat/input-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditarComponent } from './lancamentos/editar/editar.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [AppComponent, LancamentosComponent, IncluirComponent, EditarComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot({
      closeButton: true,
      progressBar: true,
      positionClass: 'toast-bottom-right',
      enableHtml: true,
    }),
    InputMaskModule.forRoot({ inputSelector: 'input', isAsync: true }),
  ],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: 'pt-BR',
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
