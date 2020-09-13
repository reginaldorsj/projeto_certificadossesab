
export class Unidade {
	private _id_unidade: number;
	private _descricao: string;
	private _ativo: boolean;

	public get IdUnidade(): number {
		return this._id_unidade;
	}

	public set IdUnidade(idUnidade: number) {
		this._id_unidade = idUnidade;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

	public get Ativo(): boolean {
		return this._ativo;
	}

	public set Ativo(ativo: boolean) {
		this._ativo = ativo;
	}

}
