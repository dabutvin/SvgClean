# SvgClean

A C# dotnet SVG optimizer.

## Options

(none..yet!)

## Steps

- RemoveNewLines
- RemoveComments
- RemoveMetadata
- RemoveEmptyText
- RemoveHiddenElements
- RemoveEditorJunk
- RemoveExtraNamespaces( todo: xmlns:junk can be removed if junk is not svg or xlink or missing)
- RemoveNonInheritableGroupAttributes (todo: if a `<g>` has an attribute that cannot be inherited, then we don't need it)
- RemoveNonSvgTags (todo: there are a finite set of svg tags that are valid)
- RemoveAttributesWithDefaultValues (todo: remove the attribute if it is a default value AND (not overriding a parent's attribute, or is not inheritable))
- CollapseGroups
- MinifyStyles
- TrimAttributes
- TrimSpaces

## Useful resources

SVG property index
https://www.w3.org/TR/SVG/propidx.html
https://www.w3.org/TR/SVG11/propidx.html

SVG attribute index
https://www.w3.org/TR/SVG/attindex.html
https://www.w3.org/TR/SVG11/attindex.html

SVG elements
https://developer.mozilla.org/en-US/docs/Web/SVG/Element
