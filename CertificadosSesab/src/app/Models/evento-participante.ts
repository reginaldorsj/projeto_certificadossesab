import {Participante} from './participante';
import {Evento} from './evento';

export class EventoParticipante {
	private _id_evento_participante: number;
	private _id_participante: Participante;
	private _id_evento: Evento;

	public get IdEventoParticipante(): number {
		return this._id_evento_participante;
	}

	public set IdEventoParticipante(idEventoParticipante: number) {
		this._id_evento_participante = idEventoParticipante;
	}

	public get Participante(): Participante {
		return this._id_participante;
	}

	public set Participante(participante : Participante) {
		this._id_participante = participante;
	}

	public get Evento(): Evento {
		return this._id_evento;
	}

	public set Evento(evento : Evento) {
		this._id_evento = evento;
	}

}
