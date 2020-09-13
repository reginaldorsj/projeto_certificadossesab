
export class Participante {
	private _id_participante: number;
	private _nome: string;
	private _cpf: string;
	private _email: string;

	public get IdParticipante(): number {
		return this._id_participante;
	}

	public set IdParticipante(idParticipante: number) {
		this._id_participante = idParticipante;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

	public get Cpf(): string {
		return this._cpf;
	}

	public set Cpf(cpf: string) {
		this._cpf = cpf;
	}

	public get Email(): string {
		return this._email;
	}

	public set Email(email: string) {
		this._email = email;
	}

}
