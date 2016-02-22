(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);throw new Error("Cannot find module '"+o+"'")}var f=n[o]={exports:{}};t[o][0].call(f.exports,function(e){var n=t[o][1][e];return s(n?n:e)},f,f.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
var for_each = require('./for_each');
var toggle_class = require('./toggle_class');
var class_list = require('./class_list');
var update_active = require('./update_active');
var more_links = require('./more_links');

function auth_handlers (elements, on_resize_body, transform) {

  var _for_each = for_each(elements);

  function append_wunderland_links (data) {
    var email = data && data.email || '';
    var variation = elements.menu.dataset.variation;
    var current = location.host;

    if (email.match(/@6wunderkinder\.com$/)) {
      remove_wunderland_links();

      ['Projects', 'Wiki', 'Ideas'].forEach(function (name) {
        var wunderland_link = document.createElement('a');
        var href = name.toLowerCase() + '.wunderlist.com';
        wunderland_link.href = 'http://' + href;
        wunderland_link.textContent = name;
        var wunderland_list_item = document.createElement('li');
        wunderland_list_item.id = 'wunderlist-wunderland-link';
        wunderland_list_item.className = 'menu-link';
        wunderland_list_item.appendChild(wunderland_link);

        var items = elements.menu_links.querySelectorAll('li');
        var last = items[items.length - 1];
        last.parentNode.insertBefore(wunderland_list_item, last);
      });
    }
  }

  function remove_wunderland_links () {
    var selector = '#wunderlist-wunderland-link';
    var existing = elements.menu_links.querySelectorAll(selector);
    [].forEach.call(existing, function (node) {
      node.parentNode.removeChild(node);
    });
  }

  function update_wunderlist_env (data) {
    var current_host = window.location.host;
    var production_host = 'www.wunderlist.com';
    var nightly_host = 'nightly.wunderlist.com';
    var beta_host = 'beta.wunderlist.com';
    var email = data && data.email || '';
    var is_wunderkinder = email.match(/@6wunderkinder\.com$/);
    var new_host = null;

    if (current_host === beta_host) {
      new_host = beta_host;
    }
    else if (is_wunderkinder || current_host === nightly_host) {
      new_host = nightly_host;
    }

    if (new_host) {
      _for_each.link(function (link) {
        var href = link.href;
        if (href.indexOf(production_host) !== -1) {
          link.href = href.replace(production_host, new_host);
        }
      });
    }
  }

  function show_user_actions (ev) {
    var data = ev.detail;
    hide_visitor_actions();

    var avatar_url = '//a.wunderlist.com/api/v1/avatar?user_id=' + data.id;
    elements.user_avatar.src = avatar_url;

    elements.user_details.username.textContent = data.name;
    elements.user_details.email.textContent = data.email;

    append_wunderland_links(data);
    update_wunderlist_env(data);
    update_active(elements);

    toggle_class(elements.user_actions, 'hidden', false);
    toggle_class(elements.conversations_toggle, 'hidden', false);
    toggle_class(elements.activities_toggle, 'hidden', false);

    if (elements.search && class_list.contains(elements.search, 'auth-only')) {
      toggle_class(elements.search, 'hidden', false);
    }

    transform();
    on_resize_body.call_handlers();
  }

  function hide_user_actions () {
    remove_wunderland_links();
    update_wunderlist_env({});
    toggle_class(elements.user_actions, 'hidden', true);
    toggle_class(elements.conversations_toggle, 'hidden', true);
    toggle_class(elements.activities_toggle, 'hidden', true);
    if (elements.search && class_list.contains(elements.search, 'auth-only')) {
      toggle_class(elements.search, 'hidden', true);
    }
    more_links(elements);
  }

  function show_visitor_actions () {
    hide_user_actions();
    Object.keys(elements.buttons).forEach(function (name) {
      var button = elements.buttons[name];
      button && toggle_class(button, 'hidden', false);
    });
    transform();
    on_resize_body.call_handlers();
  }

  function hide_visitor_actions () {
    Object.keys(elements.buttons).forEach(function (name) {
      var button = elements.buttons[name];
      button && toggle_class(button, 'hidden', true);
    });
    more_links(elements);
  }

  return {
    'show_user_actions': show_user_actions,
    'show_visitor_actions': show_visitor_actions
  };
}

module.exports = auth_handlers;

},{"./class_list":2,"./for_each":8,"./more_links":11,"./toggle_class":15,"./update_active":17}],2:[function(require,module,exports){
function add (element, name) {
  if (!contains(element, name)) {
    element.className += ' ' + name;
  }
}

function contains (element, name) {
  var classes = (element.className || '').split(' ');
  return classes.indexOf(name) !== -1;
}

function remove (element, name) {
  if (contains(element, name)) {
    var classes = (element.className || '').split(' ');
    var index = classes.indexOf(name);
    classes.splice(index, 1);
    element.className = classes.join(' ');
  }
}


module.exports = {
  'add': add,
  'remove': remove,
  'contains': contains
};
},{}],3:[function(require,module,exports){
function context (element) {

  return function _context () {

    var context = window.getComputedStyle(element, ':after').getPropertyValue('content');
    return context || 'desktop';
  };
}

module.exports = context;
},{}],4:[function(require,module,exports){
// Copyright (c) 2007-2015 David Walsh
 
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:

// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

// http://davidwalsh.name/javascript-debounce-function

// Returns a function, that, as long as it continues to be invoked, will not
// be triggered. The function will be called after it stops being called for
// N milliseconds. If `immediate` is passed, trigger the function on the
// leading edge, instead of the trailing.
function debounce(func, wait, immediate) {
  var timeout;
  return function() {
    var context = this, args = arguments;
    var later = function() {
      timeout = null;
      if (!immediate) func.apply(context, args);
    };
    var callNow = immediate && !timeout;
    clearTimeout(timeout);
    timeout = setTimeout(later, wait);
    if (callNow) func.apply(context, args);
  };
}

module.exports = debounce;
},{}],5:[function(require,module,exports){
function elements (base_element) {

  function get (suffix) {
    var class_name = '.wunderlist-' + suffix;
    var element = base_element.querySelector(class_name);
    if (!element && base_element.shadowRoot) {
      element = base_element.shadowRoot.querySelector(class_name);
    }
    return element;
  }

  return {
    'document': window.document,
    'menu': base_element,
    'menu_links': get('menu-links'),
    'more_links': get('more-links'),
    'popovers': {
      'user_links': get('user-links'),
      'conversations': get('conversations-popover'),
      'activities': get('activities-popover'),
      'more_links': get('more-links-popover'),
    },
    'user_links': {},
    'buttons': {
      'signup': get('signup-button'),
      'login': get('login-button'),
      'download': get('download-button')
    },
    'actions': get('actions'),
    'user_actions': get('user-actions'),
    'user_avatar': get('user-avatar'),
    'search': get('search'),
    'search_icon': get('search-icon'),
    'search_cancel': get('search-cancel'),
    'search_input': get('search-input'),
    'activities_toggle': get('activities-icon'),
    'conversations_toggle': get('conversations-icon'),
    'activities_count': get('activities-count'),
    'conversations_count': get('conversations-count'),
    'iframes': {
      'conversations': get('conversations-frame'),
      'activities': get('activities-frame')
    },
    'user_details': {
      'username': get('username'),
      'email': get('email')
    }
  };
}

module.exports = elements;
},{}],6:[function(require,module,exports){
function events (elements, handlers) {

  var click_event = 'touchstart' in document.documentElement ? 'touchstart' : 'click';

  function add (name, handler, event) {
    event = event || click_event;
    var element = elements[name];
    if (element && handler) {
      element.addEventListener(event, handler);
    }
  }

  add('document', handlers.hide_popovers);
  add('menu', handlers.inside_click);

  add('menu_links', handlers.show_menu_links);
  add('menu_links_toggle', handlers.toggle_menu_links);
  add('more_links', handlers.toggle_more_links);

  add('search_icon', handlers.search.toggle_search);
  add('search_cancel', handlers.search.close_search);
  add('search_input', handlers.search.handle_search_keys, 'keyup');

  add('user_actions', handlers.toggle_user_links);
  add('activities_toggle', handlers.notifications.toggle_activities);
  add('conversations_toggle', handlers.notifications.toggle_conversations);

  add('menu', handlers.auth.show_user_actions, 'auth:user');
  add('menu', handlers.auth.show_visitor_actions, 'auth:visitor');
  add('menu', handlers.notifications.enable, 'auth:user');
  add('menu', handlers.notifications.disable, 'auth:visitor');
}

module.exports = events;
},{}],7:[function(require,module,exports){
// main entry point for the menubar component

var elements = require('./elements');
var events = require('./events');
var handlers = require('./handlers');
var context = require('./context');
var user = require('./user');
var update_active = require('./update_active');
var more_links = require('./more_links');
var on_resize = require('./on_resize');
var transform_urls = require('./transform_urls');

function menubar (element, options) {

  if (!element) throw new Error('Invalid arguments, missing .wunderlist-menu element');

  options = options || {};
  options.searchUrl = options.searchUrl || '/search';
  options.searchTermName = options.searchTermName || 'q';
  options.clientId = options.clientId || element.dataset && element.dataset.clientId || '498d3ffc44ddfa2f275b';

  var initialized = false;
  function init () {
    if (initialized) return;
    initialized = true;

    var _context = context(element);
    var _user = user(element, options);
    var _elements = elements(element);
    var _transform = transform_urls(_elements, options);

    var resize_handler = more_links.bind(null, _elements);
    var on_resize_body = on_resize(_elements.body);
    on_resize_body.add_handler(resize_handler);

    var _handlers = handlers(_context, _elements, on_resize_body, _transform, options);
    on_resize_body.add_handler(_handlers.hide_popovers);
    events(_elements, _handlers);
    
    _transform();
    update_active(_elements);

    _user.authorize();
  }

  if (document.readyState === 'complete') {
    init();
  }
  else {
    window.addEventListener('load', init);
    window.addEventListener('DOMContentLoaded', init);
  }
}

window.menubar = module.exports = menubar;
},{"./context":3,"./elements":5,"./events":6,"./handlers":9,"./more_links":11,"./on_resize":13,"./transform_urls":16,"./update_active":17,"./user":18}],8:[function(require,module,exports){
function for_each (elements) {

  function link (fn) {
    var links = [].slice.call(elements.menu.querySelectorAll('a'));
    if (elements.menu.shadowRoot) {
      [].forEach.call(elements.menu.shadowRoot.querySelectorAll('a'), function (child) {
        links.push(child);
      });
    }
    var processed = [];
    [].every.call(links, function (link, index) {
      if (processed.indexOf(link) !== -1) return;
      processed.push(link);
      var result = fn(link, index);
      return result === false ? false : true;
    });
  }

  function menu_link (fn) {
    var links = [].slice.call(elements.menu_links.querySelectorAll('a'));
    if (elements.menu.shadowRoot) {
      [].forEach.call(elements.menu.children, function (child) {
        var grand_child = child.children[0];
        if (child.tagName === 'LI' && grand_child && grand_child.tagName === 'A') {
          links.push(grand_child);
        }
      });
    }
    [].every.call(links, function (link, index) {
      var result = fn(link, index);
      return result === false ? false : true;
    });
  }

  return {
    'link': link,
    'menu_link': menu_link
  };
}

module.exports = for_each;
},{}],9:[function(require,module,exports){
var toggle_class = require('./toggle_class');
var search_handlers = require('./search_handlers');
var auth_handlers = require('./auth_handlers');
var class_list = require('./class_list');
var notifications_handlers = require('./notifications_handlers');

function handlers (context, elements, on_resize_body, transform, options) {

  function toggle_popover (ev, popover) {
    var is_active = class_list.contains(popover, 'hidden');
    hide_popovers();
    toggle_class(popover, 'hidden', !is_active);
    stop_event(ev);
    return is_active;
  }

  function stop_event (ev) {
    ev.preventDefault();
    ev.stopPropagation();
  }

  function toggle_user_links (ev) {
    toggle_popover(ev, elements.popovers.user_links);
  }

  function hide_popovers () {
    Object.keys(elements.popovers).forEach(function (name) {
      class_list.add(elements.popovers[name], 'hidden');
    });
    toggle_class(elements.menu_links, 'tapped', false);
    toggle_class(elements.activities_toggle, 'active', false);
    toggle_class(elements.conversations_toggle, 'active', false);
  }

  function inside_click (ev) {
    hide_popovers();
    if (ev.target.tagName !== 'A') stop_event(ev);
  }

  function toggle_more_links (ev) {
    if (class_list.contains(elements.popovers.more_links, 'hidden')) {
      var list = elements.popovers.more_links.querySelector('ul');
      list.innerHTML = '';
      [].forEach.call(elements.menu_links.children, function (item) {
        if (class_list.contains(item, 'wunderlist-more-links')) return;
        var clone = item.cloneNode(true);
        toggle_class(clone, 'hidden');
        list.appendChild(clone);
      });
      
      var popoverWidth = 180 - 5; // hardcoded for speed
      var offset = elements.more_links.offsetLeft + elements.more_links.offsetParent.offsetLeft;
      var rightOffset = document.body.offsetWidth - offset - popoverWidth;
      elements.popovers.more_links.style.right = rightOffset + 'px';
    }

    toggle_popover(ev, elements.popovers.more_links);
  }

  var _handlers = {
    'stop_event': stop_event,
    'toggle_user_links': toggle_user_links,
    'inside_click': inside_click,
    'hide_popovers': hide_popovers,
    'toggle_popover': toggle_popover,
    'search': search_handlers(elements, on_resize_body, options),
    'auth': auth_handlers(elements, on_resize_body, transform),
    'toggle_more_links': toggle_more_links
  };

  var _notifications_handlers = notifications_handlers(elements, _handlers, options);
  _handlers.notifications = _notifications_handlers;

  return _handlers;
}

module.exports = handlers;
},{"./auth_handlers":1,"./class_list":2,"./notifications_handlers":12,"./search_handlers":14,"./toggle_class":15}],10:[function(require,module,exports){
var localStorage;
try {
  localStorage = window.localStorage;
} catch (e) {}


module.exports = localStorage;
},{}],11:[function(require,module,exports){
// responsible for showing a "more..." link if all menu_links doesn't fit

var toggle_class = require('./toggle_class');
var class_list = require('./class_list');
var for_each = require('./for_each');

function more_links (elements) {

  var list = elements.menu_links;
  var children = [].slice.call(list.children).filter(function (child) {
    return class_list.contains(child, 'menu-link');
  });
  
  var overlay = elements.actions;
  
  if (overlay.offsetWidth < 25) {
    return setTimeout(more_links.bind(null, elements), 25);
  }

  var more_link = null;
  var more_link_width = null;

  function resetMoreLinks () {
    toggle_class(elements.more_links, 'hidden', false);
    more_link = elements.more_links;
    more_link_width = elements.more_links.offsetWidth;
    toggle_class(elements.more_links, 'hidden', true);
  }

  function resetVisibility () {
    children.forEach(function (child) {
      toggle_class(child, 'hidden', false);
    });
  }

  var total = list.offsetLeft;
  var moreAddedToTotal = false;

  function next () {
    
    var item = children.shift();
    if (!item) return;

    var totalWithItem = total + item.offsetWidth;
    var cutoff = overlay.offsetLeft;
    
    if (!moreAddedToTotal) {
      moreAddedToTotal = true;
      totalWithItem += more_link_width;
    }

    if (totalWithItem < cutoff) {
      total = totalWithItem;
      children.length && next();
    }
    else {
      toggle_class(item, 'hidden', true);
      children.forEach(function (child) {
        toggle_class(child, 'hidden', true);
      });
      toggle_class(elements.more_links, 'hidden', false);
    }
  }

  setTimeout(function () {
    resetMoreLinks();
    resetVisibility();
    next();
  });
}

module.exports = more_links;
},{"./class_list":2,"./for_each":8,"./toggle_class":15}],12:[function(require,module,exports){
// event handlers for notifications

var toggle_class = require('./toggle_class');
var localStorage = require('./localstorage');

function notifications_handlers (elements, handlers, options) {

  var interval = 5000;
  var access_token = null;
  var email = null;
  var count_poller = null;
  var cache_key = 'wunderlist_notifications_cache_';

  function poll_counts (data) {

    function next () {
      count_poller = setTimeout(poll_counts.bind(null, data), interval);
    }

    var xhr = new XMLHttpRequest();
    var url = 'https://a.wunderlist.com/api/v1/unread_activity_counts';
    xhr.open('GET', url, true);
    xhr.setRequestHeader('content-type', 'application/json');
    xhr.setRequestHeader('X-Access-Token', data.access_token);
    xhr.setRequestHeader('X-Client-ID', options.clientId);

    xhr.onload = function (e) {
      if (xhr.readyState === 4) {
        if (xhr.status === 200) {
          var counts;
          try {
            counts = JSON.parse(xhr.response);
          }
          catch (ev) {}
          update_counts(counts);
          next();
        } else {
          next();
        }
      }
    };
    xhr.onerror = function (e) {
      next();
    };

    xhr.send();
  }

  function update_count (type, count) {
    var element = elements[type + '_count'];
    if (count) {
      element.textContent = count;
      toggle_class(element, 'hidden', false);
    }
    else {
      toggle_class(element, 'hidden', true);
    }
    update_title_count(type, count);
  }

  var title_counts = {};
  function update_title_count (type, count) {
    title_counts[type] = count;
    var total = 0;
    Object.keys(title_counts).forEach(function (count_type) {
      var type_count = title_counts[count_type];
      total += type_count;
    });

    var prefix_re = /^\(\d+\)\s/;
    var prefix = total ? '(' + total + ') ' : '';
    var current_title = document.title;
    if (current_title.match(prefix_re)) {
      current_title = current_title.replace(prefix_re, prefix);
    }
    else {
      current_title = prefix + current_title;
    }
    document.title = current_title;
  }

  function update_counts (counts) {
    update_count('conversations', counts.conversations);
    update_count('activities', counts.activities);
  }

  function replace_urls (doc) {
    var current_host = window.location.host;
    var production_host = 'www.wunderlist.com';
    var nightly_host = 'nightly.wunderlist.com';
    var is_wunderkinder = email.match(/@6wunderkinder\.com$/);
    var host_name = (current_host === nightly_host || is_wunderkinder) ? nightly_host : production_host;

    [].forEach.call(doc.querySelectorAll('a'), function (link) {
      link.href = link.href.replace('wunderlist://', 'https://' + host_name + '/webapp/#/');
      link.target = '_blank';
    });
  }

  function save_notifications_cache (type, iframe) {
    var key = cache_key + type;
    var html = iframe.contentWindow.document.documentElement.innerHTML;
    localStorage && localStorage.setItem(key, html);
  }

  function read_notification_cache (type, iframe) {
    var key = cache_key + type;
    var existing = localStorage && localStorage.getItem(key);
    if (existing && existing.length) {
      iframe.contentWindow.document.documentElement.innerHTML = existing;
    }
  }

  function fetch_notifications (type, iframe) {
    if (!access_token) return;//console.error('menubar: Invalid access token');
    var xhr = new XMLHttpRequest();
    var url = 'https://a.wunderlist.com/api/v1/' + type + '.html';
    xhr.open('GET', url, true);
    xhr.setRequestHeader('X-Access-Token', access_token);
    xhr.setRequestHeader('X-Client-ID', options.clientId);

    xhr.onload = function (e) {
      if (xhr.readyState === 4) {
        if (xhr.status === 200) {
          update_count(type, 0);
          iframe.contentWindow.document.documentElement.innerHTML = xhr.response;
          replace_urls(iframe.contentWindow.document);
          save_notifications_cache(type, iframe);
        }
      }
    };

    xhr.onerror = function (e) {
      console.error('menubar: Failed to load ' + type + ' notifications', e);
    };

    xhr.send();
  }

  function toggle_popover (ev, type) {
    var state = handlers.toggle_popover(ev, elements.popovers[type]);
    if (state) {
      var icon = ev.target.tagName === 'A' ? ev.target : ev.target.parentNode;
      toggle_class(icon, 'active', true);
      read_notification_cache(type, elements.iframes[type]);
      fetch_notifications(type, elements.iframes[type]);
    }
  }

  function toggle_conversations (ev) {
    toggle_popover(ev, 'conversations');
  }

  function toggle_activities (ev) {
    toggle_popover(ev, 'activities');
  }

  function enable (ev) {
    var data = ev.detail;
    access_token = data.access_token;
    email = data.email;
    count_poller = setTimeout(poll_counts.bind(null, data), 0);
  }

  function disable () {
    if (count_poller) {
      clearTimeout(count_poller);
    }
    access_token = null;
    email = null;
    toggle_class(elements.activities_toggle, 'hidden', true);
    toggle_class(elements.conversations_toggle, 'hidden', true);
  }

  return {
    'enable': enable,
    'disable': disable,
    'toggle_conversations': toggle_conversations,
    'toggle_activities': toggle_activities
  };
}

module.exports = notifications_handlers;
},{"./localstorage":10,"./toggle_class":15}],13:[function(require,module,exports){
// need to be able to artifically trigger a resize event? or just do a custom trigger event?

var debounce = require('./debounce');

function on_resize (element) {

  var handlers = [];

  function call_resize_handlers () {
    var args = [].slice.call(arguments);
    handlers.forEach(function (handler) {
      handler.apply(null, args);
    });
  }

  function add_resize_handler (handler) {
    handlers.push(handler);
  }

  window.onresize = debounce(call_resize_handlers, 100);
  
  return {
    'add_handler': add_resize_handler,
    'call_handlers': call_resize_handlers
  };
}

module.exports = on_resize;
},{"./debounce":4}],14:[function(require,module,exports){
// event handlers for search

var toggle_class = require('./toggle_class');

function search_handlers (elements, on_resize_body, options) {

  function select_search () {
    var handler = elements.search_input.select.bind(elements.search_input);
    setTimeout(handler, 250);
  }

  function toggle_search () {
    if (!toggle_class(elements.search, 'collapsed')) {
      select_search();
    }
    on_resize_body.call_handlers();
  }

  function close_search () {
    elements.search_input.value = '';
    toggle_class(elements.search, 'collapsed', true);
    on_resize_body.call_handlers();
  }

  function cancel_search () {
    var value = (elements.search_input.value || '').trim();
    if (value) {
      elements.search_input.value = '';
      select_search();
    }
    else {
      close_search();
    }
  }

  function submit_search () {
    var value = (elements.search_input.value || '').trim();
    if (value) {
      var url = options.searchUrl + '?' + options.searchTermName + '=' + encodeURIComponent(value);
      window.location.href = url;
    }
  }

  function handle_search_keys (ev) {
    switch (ev.which) {
      case 13:
        submit_search();
        break;
      case 27:
        cancel_search();
        break;
    }
  }

  return {
    'toggle_search': toggle_search,
    'close_search': close_search,
    'handle_search_keys': handle_search_keys
  };
}

module.exports = search_handlers;

},{"./toggle_class":15}],15:[function(require,module,exports){
// helper function to toggle class on an element

var class_list = require('./class_list');

function toggle_class (element, class_name, force_mode) {
  var contains = class_list.contains(element, class_name);
  if (typeof force_mode === 'boolean') contains = !force_mode;
  class_list[contains ? 'remove' : 'add'](element, class_name);
  return !contains;
}

module.exports = toggle_class;
},{"./class_list":2}],16:[function(require,module,exports){
var for_each = require('./for_each');

function transform_urls (elements, options) {

  options = options || {};
  var _for_each = for_each(elements);

  if (typeof options.transformUrls !== 'function') {
    return function () {}
  }
  else {

    return function transform () {
      _for_each.link(function (link) {
        var href = link.href;
        var updated = options.transformUrls(href);
        if (updated) {
          link.href = updated;
        }
      });
    }
  }
}

module.exports = transform_urls;
},{"./for_each":8}],17:[function(require,module,exports){
// helper function to give the right link the "active" class

var for_each = require('./for_each');
var class_list = require('./class_list');

function update_active (elements) {

  var _for_each = for_each(elements);

  var location = window.document.location;
  var hostnames = [];
  var active = null;

  var current = location.host + location.pathname;
  if (current[current.length - 1] == '/') {
    current = current.substr(0, current.length - 1);
  }
  
  _for_each.menu_link(function (link) {
    if (class_list.contains(link, 'more-links')) return;
    var hostname = link.href.split('//')[1].split('/')[0];
    if (hostnames.indexOf(hostname) === -1) hostnames.push(hostname);
    class_list.remove(link, 'active');
  });

  _for_each.menu_link(function (link) {
    if (class_list.contains(link, 'more-links')) return;

    var href = link.href.split('//')[1];
    if (href.length > 1 && href[href.length - 1] === '/') {
      href = href.substr(0, href.length - 1);
    }
    
    if (current.indexOf(href) === 0) {
      active = link;
    }
  });

  if (active) {
    class_list.add(active, 'active');
    class_list.add(active.parentNode, 'active');
  }
}

module.exports = update_active;
},{"./class_list":2,"./for_each":8}],18:[function(require,module,exports){
var cache_key = 'wunderlist_menubar_user';
var localStorage = require('./localstorage');

function user (element, options) {

  function save_auth_cache (data) {
     localStorage && localStorage.setItem(cache_key, JSON.stringify(data));
  }

  function clear_auth_cache () {
    localStorage && localStorage.removeItem(cache_key);
  }

  function check_auth_cache () {
    var existing = localStorage && localStorage.getItem(cache_key);
    if (existing && existing.id) {
      dispatch_event(existing);
    }
  }

  function check_dataset_auth () {
    var data = {};
    var dataset = element.dataset || {};
    data.id = dataset.uid || options.uid;
    data.email = dataset.email || options.email;
    data.name = dataset.username || options.username;
    data.access_token = dataset.accessToken || options.accessToken;
    if (data.id && data.access_token) {
      dispatch_event(data);
      return true;
    }
    return false;
  }

  function fire_event (event, data) {
    var evt;
    if (document.createEventObject){
      // dispatch for IE
      evt = document.createEventObject();
      evt.detail = data;
      return this.fireEvent('on' + event, evt);
    } else {
      // dispatch for firefox + others
      evt = document.createEvent('HTMLEvents');
      evt.detail = data;
      evt.initEvent(event, true, true); // event type, bubbling, cancelable
      return !this.dispatchEvent(evt);
    }
  }

  function dispatch_event (data) {
    var event_name = data && data.id ? 'auth:user' : 'auth:visitor';
    fire_event.call(element, event_name, data);
  }

  function check_auth () {
    var xhr = new XMLHttpRequest();
    var url = window.location.protocol + '//' + window.location.host + '/authorize';
    xhr.open('POST', url, true);
    xhr.setRequestHeader('content-type', 'application/json');
    xhr.onload = function (e) {
      if (xhr.readyState === 4) {
        if (xhr.status === 200) {
          var data;
          try {
            data = JSON.parse(xhr.response);
            save_auth_cache(data);
            dispatch_event(data);
          }
          catch (err) {
            dispatch_event(false);
            clear_auth_cache();
          }
        } else {
          dispatch_event(false);
          clear_auth_cache();
        }
      }
    };
    xhr.onerror = function (e) {
      dispatch_event(false);
      clear_auth_cache();
    };
    xhr.send(JSON.stringify({ client_id: options.clientId}));
  }

  function authorize () {
    if (!check_dataset_auth()) {
      check_auth_cache();
      check_auth();
    }
  }

  return {
    'authorize': authorize
  };
}

module.exports = user;
},{"./localstorage":10}]},{},[7])