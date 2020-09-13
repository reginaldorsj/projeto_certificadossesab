import { TestBed } from '@angular/core/testing';

import { EventoParticipanteService } from './evento-participante.service';

describe('EventoParticipanteService', () => {
  let service: EventoParticipanteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventoParticipanteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
