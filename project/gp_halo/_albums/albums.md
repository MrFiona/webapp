---
title: albums
author: dave
---

{% assign author = site.data.people[page.author] %}
<a rel="author"
  href="{{ author.twitter }}"
  title="{{ author.name }}">
    {{ author.name }}
</a>