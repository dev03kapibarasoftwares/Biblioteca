import { TesteTemplatePage } from './app.po';

describe('Teste App', function() {
  let page: TesteTemplatePage;

  beforeEach(() => {
    page = new TesteTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
