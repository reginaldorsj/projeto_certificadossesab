import { Injectable } from '@angular/core';

import {Evento} from './evento';
import {EventoParticipante} from './evento-participante';
import {Historico} from './historico';
import {Participante} from './participante';
import {Unidade} from './unidade';
import {Usuario} from './usuario';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  private classes = {
		Evento,
		EventoParticipante,
		Historico,
		Participante,
		Unidade,
		Usuario
  };

  constructor() { }

  convertTimeZone(date: Date): Date {
    if (date)
      return new Date(date.getTime() - (date.getTimezoneOffset() * 60000));
    return date;
  }

  deepCopy(sourceObject, destinationObject) {
    for (const key in sourceObject) {
      if (typeof sourceObject[key] != 'object') {
        destinationObject[key] = sourceObject[key];
      } else {
        let keys: string[] = Object.keys(sourceObject[key]);
        destinationObject[key] = this.get(keys[0]);
        this.deepCopy(sourceObject[key], destinationObject[key]);
      }
    }
  }

  protected get(_id_classe: string): any {
    let classe: string = this.getClassName(_id_classe);
    return new this.classes[classe];
  }

  protected getClassName(idProperty: string): string {

    let ret: string = '';
    let i: number = 3;
    while (i < idProperty.length) {
      if (idProperty[i] == '_') {
        ret = ret + idProperty[i + 1].toUpperCase();
        i++;
      }
      else {
        ret = ret + idProperty[i];
      }
      i++;
    }
    return ret;
  }
}

