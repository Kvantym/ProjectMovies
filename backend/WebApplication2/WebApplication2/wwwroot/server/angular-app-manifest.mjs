
export default {
  bootstrap: () => import('./main.server.mjs').then(m => m.default),
  inlineCriticalCss: true,
  baseHref: '/',
  locale: undefined,
  routes: [
  {
    "renderMode": 2,
    "route": "/"
  }
],
  entryPointToBrowserMapping: undefined,
  assets: {
    'index.csr.html': {size: 642, hash: '78df6c82e76f35a0905d0e401e8c74dc1e880e98bf6fa40b59d895d37a59dfd9', text: () => import('./assets-chunks/index_csr_html.mjs').then(m => m.default)},
    'index.server.html': {size: 993, hash: 'f068813da5176526d3dcbe5f6b86c9f4da157d78b1ab69af7c410098f49382f9', text: () => import('./assets-chunks/index_server_html.mjs').then(m => m.default)},
    'index.html': {size: 4596, hash: '8bbfc6271766d6b681403cccb426f77e388fa75aee8c1caf6194e08d4632d38b', text: () => import('./assets-chunks/index_html.mjs').then(m => m.default)},
    'styles-QVQ2QZRI.css': {size: 37, hash: 'oMaGgKd9/CM', text: () => import('./assets-chunks/styles-QVQ2QZRI_css.mjs').then(m => m.default)}
  },
};
