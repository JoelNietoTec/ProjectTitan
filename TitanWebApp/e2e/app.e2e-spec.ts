import { TitanWebAppPage } from './app.po';

describe('titan-web-app App', () => {
  let page: TitanWebAppPage;

  beforeEach(() => {
    page = new TitanWebAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
