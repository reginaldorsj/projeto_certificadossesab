import {EventoParticipante} from './evento-participante';

export class Historico {
	private _id_historico: number;
	private _id_evento_participante: EventoParticipante;
	private _data_hora: Date;

	public get IdHistorico(): number {
		return this._id_historico;
	}

	public set IdHistorico(idHistorico: number) {
		this._id_historico = idHistorico;
	}

	public get EventoParticipante(): EventoParticipante {
		return this._id_evento_participante;
	}

	public set EventoParticipante(eventoParticipante : EventoParticipante) {
		this._id_evento_participante = eventoParticipante;
	}

	public get DataHora(): Date {
		if (this._data_hora && !(this._data_hora instanceof Date)) {
			this._data_hora = new Date(this._data_hora);
		}
		return this._data_hora; 
	}

	public set DataHora(dataHora: Date) {
		this._data_hora = dataHora;
	}

}
