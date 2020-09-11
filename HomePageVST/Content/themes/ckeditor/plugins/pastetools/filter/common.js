﻿/*
 Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
*/
(function () {
    function q(a) { return /%$/.test(a) ? a : a + "px" } function r(a) { var b = a.margin ? "margin" : a.MARGIN ? "MARGIN" : !1, c, e; if (b) { e = CKEDITOR.tools.style.parse.margin(a[b]); for (c in e) a["margin-" + c] = e[c]; delete a[b] } } function t(a) {
        var b = "background-color:transparent;background:transparent;background-color:none;background:none;background-position:initial initial;background-repeat:initial initial;caret-color;font-family:-webkit-standard;font-variant-caps;letter-spacing:normal;orphans;widows;text-transform:none;word-spacing:0px;-webkit-text-size-adjust:auto;-webkit-text-stroke-width:0px;text-indent:0px;margin-bottom:0in".split(";"),
        c = CKEDITOR.tools.parseCssText(a.attributes.style), e, f; for (e in c) f = e + ":" + c[e], CKEDITOR.tools.array.some(b, function (a) { return f.substring(0, a.length).toLowerCase() === a }) && delete c[e]; c = CKEDITOR.tools.writeCssText(c); "" !== c ? a.attributes.style = c : delete a.attributes.style
    } function u(a) { a = a.config.font_names; var b = []; if (!a || !a.length) return !1; b = CKEDITOR.tools.array.map(a.split(";"), function (a) { return -1 === a.indexOf("/") ? a : a.split("/")[1] }); return b.length ? b : !1 } function v(a, b) {
        var c = a.split(","); return CKEDITOR.tools.array.find(b,
        function (a) { for (var f = 0; f < c.length; f++) if (-1 === a.indexOf(CKEDITOR.tools.trim(c[f]))) return !1; return !0 }) || a
    } var h, l = CKEDITOR.tools, p = {}; CKEDITOR.plugins.pastetools.filters.common = p; p.rules = function (a, b, c) {
        var e = u(b); return {
            elements: {
                "^": function (a) { t(a); if (a.attributes.bgcolor) { var b = CKEDITOR.tools.parseCssText(a.attributes.style); b["background-color"] || (b["background-color"] = a.attributes.bgcolor, a.attributes.style = CKEDITOR.tools.writeCssText(b)) } }, span: function (a) { if (a.hasClass("Apple-converted-space")) return new CKEDITOR.htmlParser.text(" ") },
                table: function (a) { a.filterChildren(c); var b = a.parent, d = b && b.parent, e, k; if (b.name && "div" === b.name && b.attributes.align && 1 === l.object.keys(b.attributes).length && 1 === b.children.length) { a.attributes.align = b.attributes.align; e = b.children.splice(0); a.remove(); for (k = e.length - 1; 0 <= k; k--) d.add(e[k], b.getIndex()); b.remove() } h.convertStyleToPx(a) }, tr: function (a) { a.attributes = {} }, td: function (a) {
                    var g = a.getAscendant("table"), g = l.parseCssText(g.attributes.style, !0), d = g.background; d && h.setStyle(a, "background", d,
                    !0); (g = g["background-color"]) && h.setStyle(a, "background-color", g, !0); var g = l.parseCssText(a.attributes.style, !0), d = g.border ? CKEDITOR.tools.style.border.fromCssRule(g.border) : {}, d = l.style.border.splitCssValues(g, d), e = CKEDITOR.tools.clone(g), k; for (k in e) 0 == k.indexOf("border") && delete e[k]; a.attributes.style = CKEDITOR.tools.writeCssText(e); g.background && (k = CKEDITOR.tools.style.parse.background(g.background), k.color && (h.setStyle(a, "background-color", k.color, !0), h.setStyle(a, "background", ""))); for (var m in d) k =
                    g[m] ? CKEDITOR.tools.style.border.fromCssRule(g[m]) : d[m], "none" === k.style ? h.setStyle(a, m, "none") : h.setStyle(a, m, k.toString()); h.mapCommonStyles(a); h.convertStyleToPx(a); h.createStyleStack(a, c, b, /margin|text\-align|padding|list\-style\-type|width|height|border|white\-space|vertical\-align|background/i)
                }, font: function (a) { a.attributes.face && e && (a.attributes.face = v(a.attributes.face, e)) }
            }
        }
    }; p.styles = {
        setStyle: function (a, b, c, e) {
            var f = l.parseCssText(a.attributes.style); e && f[b] || ("" === c ? delete f[b] : f[b] =
            c, a.attributes.style = CKEDITOR.tools.writeCssText(f))
        }, convertStyleToPx: function (a) { var b = a.attributes.style; b && (a.attributes.style = b.replace(/\d+(\.\d+)?pt/g, function (a) { return CKEDITOR.tools.convertToPx(a) + "px" })) }, mapStyles: function (a, b) { for (var c in b) if (a.attributes[c]) { if ("function" === typeof b[c]) b[c](a.attributes[c]); else h.setStyle(a, b[c], a.attributes[c]); delete a.attributes[c] } }, mapCommonStyles: function (a) {
            return h.mapStyles(a, {
                vAlign: function (b) { h.setStyle(a, "vertical-align", b) }, width: function (b) {
                    h.setStyle(a,
                    "width", q(b))
                }, height: function (b) { h.setStyle(a, "height", q(b)) }
            })
        }, normalizedStyles: function (a, b) {
            var c = "background-color:transparent border-image:none color:windowtext direction:ltr mso- visibility:visible div:border:none".split(" "), e = "font-family font font-size color background-color line-height text-decoration".split(" "), f = function () { for (var a = [], b = 0; b < arguments.length; b++) arguments[b] && a.push(arguments[b]); return -1 !== l.indexOf(c, a.join(":")) }, g = !0 === CKEDITOR.plugins.pastetools.getConfigValue(b,
            "removeFontStyles"), d = l.parseCssText(a.attributes.style); "cke:li" == a.name && (d["TEXT-INDENT"] && d.MARGIN ? (a.attributes["cke-indentation"] = p.lists.getElementIndentation(a), d.MARGIN = d.MARGIN.replace(/(([\w\.]+ ){3,3})[\d\.]+(\w+$)/, "$10$3")) : delete d["TEXT-INDENT"], delete d["text-indent"]); for (var n = l.object.keys(d), k = 0; k < n.length; k++) {
                var m = n[k].toLowerCase(), h = d[n[k]], q = CKEDITOR.tools.indexOf; (g && -1 !== q(e, m.toLowerCase()) || f(null, m, h) || f(null, m.replace(/\-.*$/, "-")) || f(null, m) || f(a.name, m, h) || f(a.name,
                m.replace(/\-.*$/, "-")) || f(a.name, m) || f(h)) && delete d[n[k]]
            } var t = CKEDITOR.plugins.pastetools.getConfigValue(b, "keepZeroMargins"); r(d); (function () { CKEDITOR.tools.array.forEach(["top", "right", "bottom", "left"], function (a) { a = "margin-" + a; if (a in d) { var b = CKEDITOR.tools.convertToPx(d[a]); b || t ? d[a] = b ? b + "px" : 0 : delete d[a] } }) })(); return CKEDITOR.tools.writeCssText(d)
        }, createStyleStack: function (a, b, c, e) {
            var f = []; a.filterChildren(b); for (b = a.children.length - 1; 0 <= b; b--) f.unshift(a.children[b]), a.children[b].remove();
            h.sortStyles(a); b = l.parseCssText(h.normalizedStyles(a, c)); c = a; var g = "span" === a.name, d; for (d in b) if (!d.match(e || /margin((?!-)|-left|-top|-bottom|-right)|text-indent|text-align|width|border|padding/i)) if (g) g = !1; else { var n = new CKEDITOR.htmlParser.element("span"); n.attributes.style = d + ":" + b[d]; c.add(n); c = n; delete b[d] } CKEDITOR.tools.isEmpty(b) ? delete a.attributes.style : a.attributes.style = CKEDITOR.tools.writeCssText(b); for (b = 0; b < f.length; b++) c.add(f[b])
        }, sortStyles: function (a) {
            for (var b = ["border", "border-bottom",
            "font-size", "background"], c = l.parseCssText(a.attributes.style), e = l.object.keys(c), f = [], g = [], d = 0; d < e.length; d++) -1 !== l.indexOf(b, e[d].toLowerCase()) ? f.push(e[d]) : g.push(e[d]); f.sort(function (a, c) { var d = l.indexOf(b, a.toLowerCase()), f = l.indexOf(b, c.toLowerCase()); return d - f }); e = [].concat(f, g); f = {}; for (d = 0; d < e.length; d++) f[e[d]] = c[e[d]]; a.attributes.style = CKEDITOR.tools.writeCssText(f)
        }, pushStylesLower: function (a, b, c) {
            if (!a.attributes.style || 0 === a.children.length) return !1; b = b || {}; var e = {
                "list-style-type": !0,
                width: !0, height: !0, border: !0, "border-": !0
            }, f = l.parseCssText(a.attributes.style), g; for (g in f) if (!(g.toLowerCase() in e || e[g.toLowerCase().replace(/\-.*$/, "-")] || g.toLowerCase() in b)) { for (var d = !1, n = 0; n < a.children.length; n++) { var k = a.children[n]; if (k.type === CKEDITOR.NODE_TEXT && c) { var m = new CKEDITOR.htmlParser.element("span"); m.setHtml(k.value); k.replaceWith(m); k = m } k.type === CKEDITOR.NODE_ELEMENT && (d = !0, h.setStyle(k, g, f[g])) } d && delete f[g] } a.attributes.style = CKEDITOR.tools.writeCssText(f); return !0
        }, inliner: {
            filtered: "break-before break-after break-inside page-break page-break-before page-break-after page-break-inside".split(" "),
            parse: function (a) {
                function b(a) { var b = new CKEDITOR.dom.element("style"), c = new CKEDITOR.dom.element("iframe"); c.hide(); CKEDITOR.document.getBody().append(c); c.$.contentDocument.documentElement.appendChild(b.$); b.$.textContent = a; c.remove(); return b.$.sheet } function c(a) { var b = a.indexOf("{"), c = a.indexOf("}"); return e(a.substring(b + 1, c), !0) } var e = CKEDITOR.tools.parseCssText, f = h.inliner.filter, g = a.is ? a.$.sheet : b(a); a = []; var d; if (g) for (g = g.cssRules, d = 0; d < g.length; d++) g[d].type === window.CSSRule.STYLE_RULE &&
                a.push({ selector: g[d].selectorText, styles: f(c(g[d].cssText)) }); return a
            }, filter: function (a) { var b = h.inliner.filtered, c = l.array.indexOf, e = {}, f; for (f in a) -1 === c(b, f) && (e[f] = a[f]); return e }, sort: function (a) { return a.sort(function (a) { var c = CKEDITOR.tools.array.map(a, function (a) { return a.selector }); return function (a, b) { var g = -1 !== ("" + a.selector).indexOf(".") ? 1 : 0, g = (-1 !== ("" + b.selector).indexOf(".") ? 1 : 0) - g; return 0 !== g ? g : c.indexOf(b.selector) - c.indexOf(a.selector) } }(a)) }, inline: function (a) {
                var b = h.inliner.parse,
                c = h.inliner.sort, e = function (a) { a = (new DOMParser).parseFromString(a, "text/html"); return new CKEDITOR.dom.document(a) }(a); a = e.find("style"); c = c(function (a) { var c = [], d; for (d = 0; d < a.count() ; d++) c = c.concat(b(a.getItem(d))); return c }(a)); CKEDITOR.tools.array.forEach(c, function (a) { var b = a.styles; a = e.find(a.selector); var c, h, k; r(b); for (k = 0; k < a.count() ; k++) c = a.getItem(k), h = CKEDITOR.tools.parseCssText(c.getAttribute("style")), r(h), h = CKEDITOR.tools.extend({}, h, b), c.setAttribute("style", CKEDITOR.tools.writeCssText(h)) });
                return e
            }
        }
    }; h = p.styles; p.lists = { getElementIndentation: function (a) { a = l.parseCssText(a.attributes.style); if (a.margin || a.MARGIN) { a.margin = a.margin || a.MARGIN; var b = { styles: { margin: a.margin } }; CKEDITOR.filter.transformationsTools.splitMarginShorthand(b); a["margin-left"] = b.styles["margin-left"] } return parseInt(l.convertToPx(a["margin-left"] || "0px"), 10) } }; p.elements = { replaceWithChildren: function (a) { for (var b = a.children.length - 1; 0 <= b; b--) a.children[b].insertAfter(a) } }; p.createAttributeStack = function (a, b) {
        var c,
        e = []; a.filterChildren(b); for (c = a.children.length - 1; 0 <= c; c--) e.unshift(a.children[c]), a.children[c].remove(); c = a.attributes; var f = a, g = !0, d; for (d in c) if (g) g = !1; else { var h = new CKEDITOR.htmlParser.element(a.name); h.attributes[d] = c[d]; f.add(h); f = h; delete c[d] } for (c = 0; c < e.length; c++) f.add(e[c])
    }; p.parseShorthandMargins = r
})();