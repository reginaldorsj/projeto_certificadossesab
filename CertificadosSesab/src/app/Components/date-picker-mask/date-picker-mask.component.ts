import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-date-picker-mask',
  templateUrl: './date-picker-mask.component.html',
  styleUrls: ['./date-picker-mask.component.css']
})
export class DatePickerMaskComponent implements OnInit {

  br = {
    firstDayOfWeek: 0,
    dayNames: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
    dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
    dayNamesMin: ["Do", "Se", "Te", "Qua", "Qui", "Se", "Sa"],
    monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
    monthNamesShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
    today: 'Hoje',
    clear: 'Limpar',
    dateFormat: 'dd/mm/yy',
    weekHeader: 'SM'
  };


  @Input() stringDate: string;
  date: Date;
  @Output() dataEnviada = new EventEmitter();

  show: boolean;

  constructor() { }

  ngOnInit(): void {
    this.show = false;
  }

  mostraCalendar(): void {
    this.show = !this.show;
    this.dataAtual();
  }

  select(): void {
    this.show = false;
    this.stringDate = this.date.toLocaleDateString("pt-BR");
    this.dataEnviada.emit(this.date);
  }

  clearClick(): void {
    this.show = false;
    this.stringDate = undefined;
    this.date = undefined;
    this.dataEnviada.emit();
  }

  complete(): void {
    this.show = false;
    this.dataAtual();
  }

  input(): void {
    this.show = false;
  }

  blur(): void {
    this.dataAtual();
  }

  private dataAtual(): void {
    if (!this.stringDate)
      return;

    let arrayDate = this.stringDate.split('/');
    var dataAtual = new Date(Number.parseInt(arrayDate[2]), Number.parseInt(arrayDate[1]) - 1, Number.parseInt(arrayDate[0]));
    if (this.stringDate == dataAtual.toLocaleDateString("pt-BR")) {
      this.date = dataAtual;
      this.dataEnviada.emit(this.date);
    } else {
      this.stringDate = undefined;
      this.date = undefined;
      this.dataEnviada.emit();
    }
  }
}
